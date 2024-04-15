<template>
  <div>
    <div class="search">
      <el-form ref="formRef" :model="queryForm" label-width="120px" size="small">
        <el-form-item prop="keys" label="遥测属性" class="z-search-keys">
          <div class="z-checkbox-group">
            <el-checkbox-group v-model="queryForm.keys">
              <el-checkbox v-for="key in state.telemetryKeys" :label="key" :key="key"/>
            </el-checkbox-group>
          </div>
<!--          <el-button  type="primary" @click="backToRealtime">-->
<!--            <el-icon><ArrowLeft /></el-icon>返回实时遥测</el-button>-->
        </el-form-item>
        <el-form-item prop="datetimeRange" :label="getTagViewNameI18n('timeInterval')">
          <div style="width:100px">
            <el-date-picker
                v-model="queryForm.datetimeRange"
                type="datetimerange"
                :shortcuts="shortcuts"
                range-separator="To"
                start-placeholder="Start date"
                end-placeholder="End date"
            />
          </div>
        </el-form-item>
        <el-form-item prop="every" :label="getTagViewNameI18n('timeInterval')">
          <el-time-picker v-model="queryForm.every" :placeholder="getTagViewNameI18n('timeInterval')" value-format="HH:mm:ss"/>
        </el-form-item>
        <el-form-item prop="aggregate" :label="getTagViewNameI18n('valueMethod')">
          <el-radio-group v-model="queryForm.aggregate">
            <el-radio-button label="None">{{ getTagViewNameI18n('None') }}</el-radio-button>
            <el-radio-button label="Mean">{{ getTagViewNameI18n('Mean') }}</el-radio-button>
            <el-radio-button label="Median">{{ getTagViewNameI18n('Median') }}</el-radio-button>
            <el-radio-button label="Last">{{ getTagViewNameI18n('Last') }}</el-radio-button>
            <el-radio-button label="First">{{ getTagViewNameI18n('First') }}</el-radio-button>
            <el-radio-button label="Max">{{ getTagViewNameI18n('Max') }}</el-radio-button>
            <el-radio-button label="Min">{{ getTagViewNameI18n('Min') }}</el-radio-button>
            <el-radio-button label="Sum">{{ getTagViewNameI18n('Sum') }}</el-radio-button>
          </el-radio-group>
        </el-form-item>
        <el-form-item class="z-search-button-area">
          <div>
            <el-button type="primary" @click="search">{{ getTagViewNameI18n('query') }}</el-button>
            <el-button @click="resetForm(formRef)">{{ getTagViewNameI18n('reset') }}</el-button>
          </div>
          <el-radio-group v-model="dataDisplayStatus" class="ml-12px">
            <el-radio-button label="chart">{{ getTagViewNameI18n('chart') }}</el-radio-button>
            <el-radio-button label="dataTable">{{ getTagViewNameI18n('data') }}</el-radio-button>
          </el-radio-group>

        </el-form-item>
      </el-form>
    </div>
    <!--    表格数据 -->
    <div v-show="dataDisplayStatus === 'dataTable'" class="z-table">
      <el-table :data="tableData" style="width: 100%" size="small" v-loading="loading">
        <el-table-column prop="keyName" :label="getTagViewNameI18n('keyName')"></el-table-column>
        <el-table-column prop="value" :label="getTagViewNameI18n('value')"></el-table-column>
        <el-table-column prop="dataType" :label="getTagViewNameI18n('dataType')"></el-table-column>
        <el-table-column prop="dateTime" :label="getTagViewNameI18n('dateTime')" :formatter="formatColumnDataTime"></el-table-column>
      </el-table>
    </div>
    <div v-show="dataDisplayStatus === 'chart'">
      <div style="height: 330px" ref="messageChartRef" v-loading="loading"></div>
    </div>
  </div>
</template>

<script setup lang="ts">
import {dateUtil, ElDateTimePickerShortcuts, formatToDateTime} from "/@/utils/dateUtil";
import {deviceApi} from "/@/api/devices";
import { ref } from "vue";
import { EChartsOption } from "echarts";
import * as echarts from "echarts";
import _ from 'lodash-es';
import { telemetryHistoryChartOptions } from "/@/views/iot/devices/detail/telemetryHistoryChartOptions";
import { createDeviceRulesCrudOptions } from "/@/views/iot/devices/detail/deviceRulesCrudOptions";
import {getTagViewNameI18n} from "/@/utils/other";
const formatColumnDataTime = (row, column, cellValue, index) => {
  return formatToDateTime(cellValue)
}
const formRef = ref()
const loading = ref(false)
// const dataDisplayStatus = ref('dataTable')
const dataDisplayStatus = ref('chart')
const messageChartRef = ref();
let historyChart:any = null

interface IQueryForm {
  pi: number;
  ps: number;
  deviceId: string;
  keys: string | any;
  end: string | Date;
  every: string;
  begin: string | Date;
  sorter: string;
  aggregate: string;
  status: any;
  datetimeRange: Date | number | string | Array<Date>
}


const shortcuts = ElDateTimePickerShortcuts

const props = defineProps({
  deviceId: {
    type: String,
    default: ''
  },
})
const queryInitialState = {
  pi: 0,
  deviceId: props.deviceId,
  ps: 10,
  keys: [],
  every: '01:00:00',
  aggregate: 'Mean',
  begin: dateUtil().subtract(1, 'day').toISOString(),
  end: dateUtil().toISOString(),
  sorter: '',
  status: null,
  datetimeRange: []
}
const queryForm: IQueryForm = reactive({...queryInitialState })
const tableData = ref([])


const search = async () => {
  if (queryForm.keys.length === 0) {
    ElMessage.warning('请选择遥测属性')
    return
  }
  await getData()
}
const resetForm = (formEl) => {
  if (!formEl) return
  formEl.resetFields()
}
// const backToRealtime = ()=>{
//   proxy.mittBus.emit('updateTelemetryPageSate', 'realtime')
//
// }
const getData = async () => {
  const params = {...queryForm}
  if (params.datetimeRange[0]) params.begin = params.datetimeRange[0]
  if (params.datetimeRange[1]) params.end = params.datetimeRange[1]
  console.log(`%cgetData@DeviceDetailTelemetryHistory:148`, 'color:black;font-size:16px;background:yellow;font-weight: bold;', params.keys)
  params.keys = params.keys.join(',')
  params.every = '0.' + params.every + ':000';
  loading.value = true
  try {
    const res = await deviceApi().getDeviceTelemetryData(props.deviceId, params)
    tableData.value = res.data
    updateChart(res.data)
  } catch (e) { /* empty */ }
  loading.value = false
}
const updateChart = (rawData) => {
  let series = []
  let xAxisData = []
  series = queryForm.keys.map((key)=>{
    return {
      name: key,
      type: 'line',
      smooth: true,
      symbol: 'none',
      data: [],
      seriesLayoutBy: 'row'
    }
  })
  Object.entries(_.groupBy(rawData, 'dateTime')).forEach(([dateTime, values])=>{
    xAxisData.push(dateTime)
    for (const data of values) {
      const seriesItem = series.find((x)=>x.name === data.keyName)
      seriesItem.data.push(data.value)

    }
  })
  telemetryHistoryChartOptions.series = series
  telemetryHistoryChartOptions.xAxis.data = xAxisData
  historyChart.setOption(telemetryHistoryChartOptions, {
    replaceMerge: ["series", "yAxis", "xAxis"],
  });
}
const initChart = (target: any, option: EChartsOption) => {
  historyChart = echarts.init(target.value);
  historyChart.setOption(option);
};
const state = reactive({
  telemetryKeys: []
})
const getTelemetryKeys = async (deviceId) => {
  const res = await deviceApi().getDeviceLatestTelemetry(deviceId);
  console.log(`%c-getTelemetryKeys@DeviceDetailTelemetryHistory:193`, 'color:white;font-size:16px;background:blue;font-weight: bold;',res)
  state.telemetryKeys = res.data.filter((x) => typeof x.value === 'number').map((c) => c.keyName);
}
watch(() => props.deviceId, async () => {
  await getTelemetryKeys(props.deviceId);
  telemetryHistoryChartOptions.series = []
  telemetryHistoryChartOptions.xAxis.data = []
  historyChart.setOption(telemetryHistoryChartOptions, {
    replaceMerge: ["series", "yAxis", "xAxis"],
  });
  formRef.value.resetFields()
})

onMounted(async ()=>{
  await getTelemetryKeys(props.deviceId)
  initChart(messageChartRef, telemetryHistoryChartOptions as EChartsOption);
})
</script>

<style lang="scss" scoped>
.z-table {
  width: 100%;
  height: calc(100vh - 380px);
  overflow: auto;
}

.z-search-button-area {
  padding-right: 20px;

  :deep(.el-form-item__content) {
    display: flex;
    justify-content: space-between;
  }

}
.z-search-keys {
  :deep(.el-form-item__content) {
    display: flex;
    justify-content: space-between;
    flex-wrap: nowrap;
    align-items: start;
    .z-checkbox-group {

    }
  }
}
</style>
