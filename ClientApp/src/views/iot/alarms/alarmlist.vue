<template>
  <component :is="wrapper">
    <el-form size="default" label-width="100px" class="mt-10px">
      <el-row :gutter="35">
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('createTime')">
            <el-date-picker v-model="query.AckDateTime" type="daterange" :start-placeholder="getMenuViewNameI18n('startTime')"
              :end-placeholder="getMenuViewNameI18n('endTime')" />
          </el-form-item>
        </el-col>
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('clearTime')">
            <el-date-picker v-model="query.ClearDateTime" type="daterange" :start-placeholder="getMenuViewNameI18n('startTime')"
              :end-placeholder="getMenuViewNameI18n('endTime')" />
          </el-form-item>
        </el-col>
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('continuousStartUpTime')">
            <el-date-picker v-model="query.StartDateTime" type="daterange" :start-placeholder="getMenuViewNameI18n('startTime')"
              :end-placeholder="getMenuViewNameI18n('endTime')" />
          </el-form-item>
        </el-col>
      </el-row>

      <el-row :gutter="35">
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('waitingEndTime')">
            <el-date-picker v-model="query.EndDateTime" type="daterange" :start-placeholder="getMenuViewNameI18n('startTime')"
              :end-placeholder="getMenuViewNameI18n('endTime')" />
          </el-form-item>
        </el-col>
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('alarmType')">
            <el-input v-model="query.AlarmType" :placeholder="getMenuViewNameI18n('Please enter the alarm type:')" />
          </el-form-item>
        </el-col>
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('alarmStatus')">
            <el-select v-model="query.alarmStatus" :placeholder="getMenuViewNameI18n('Please enter the alarm status:')">
              <el-option v-for="item in alarmStatusOptions" :key="item.value" :label="item.label" :value="item.value" />
            </el-select>
          </el-form-item>
        </el-col>
      </el-row>

      <el-row :gutter="35">
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('serverity')">
            <el-select v-model="query.serverity" :placeholder="getMenuViewNameI18n('Please enter the serverity')">
              <el-option v-for="item in serverityOptions" :key="item.value" :label="item.label" :value="item.value" />
            </el-select>
          </el-form-item>
        </el-col>
        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('sourceAlarmType')">
            <el-select v-model="query.originatorType" :placeholder="getMenuViewNameI18n('Please select the source of the cause')">
              <el-option v-for="item in originatorTypeOptions" :key="item.value" :label="item.label"
                :value="item.value" />
            </el-select>
          </el-form-item>
        </el-col>


        <el-col :xs="24" :sm="12" :md="8" :lg="8" :xl="8">
          <el-form-item :label="getMenuViewNameI18n('originatorId')">
            <el-select v-model="query.OriginatorId" :laceholder="getMenuViewNameI18n('Please select the object of interest')" filterable remote reserve-keyword
                  :remote-method="getOriginators" :loading="tableData.originatorloading">
              <el-option v-for="item in tableData.originatorOptions" :key="item.value" :label="item.label"
                :value="item.value" />
            </el-select>
          </el-form-item>
        </el-col>
      </el-row>
      <el-form-item>
        <el-button size="default" type="primary" @click="getData()">
          <el-icon>
            <ele-Search />
          </el-icon>
          <span>{{getMenuViewNameI18n('query')}}</span>
        </el-button>
      </el-form-item>

    </el-form>
    <el-row>

    </el-row>


    <el-table :data="tableData.rows" style="width: 100%" row-key="id" v-loading="loading">

      <el-table-column type="expand">
        <template #default="props">
          <el-descriptions :title="getMenuViewNameI18n('sourceAlarmType')">
            <el-descriptions-item label="Id">{{ props.row.originator.id }}</el-descriptions-item>
            <el-descriptions-item label="名称">{{ props.row.originator.name }}</el-descriptions-item>
          </el-descriptions>
        </template>
      </el-table-column>
      <el-table-column prop="alarmType" :label="getMenuViewNameI18n('alarmType')" show-overflow-tooltip></el-table-column>
      <el-table-column prop="ackDateTime" :label="getMenuViewNameI18n('createTime')" show-overflow-tooltip></el-table-column>
      <el-table-column prop="startDateTime" :label="getMenuViewNameI18n('startDateTime')" show-overflow-tooltip></el-table-column>
      <el-table-column prop="endDateTime" :label="getMenuViewNameI18n('endDateTime')" show-overflow-tooltip></el-table-column>
      <el-table-column prop="清除时间" :label="getMenuViewNameI18n('clearTime')" show-overflow-tooltip></el-table-column>
      <el-table-column prop="alarmStatus" :label="getMenuViewNameI18n('alarmStatus')" show-overflow-tooltip>
        <template #default="scope">
          <el-tag size="small"
            :style="{ color: 'white', borderColor: alarmStatusTAG.get(scope.row.alarmStatus)?.color }"
            :color="alarmStatusTAG.get(scope.row.alarmStatus)?.color" disable-transitions>{{
                alarmStatusTAG.get(scope.row.alarmStatus)?.text
            }}
          </el-tag>
        </template>
      </el-table-column>

      <el-table-column prop="serverity" :label="getMenuViewNameI18n('serverity')" show-overflow-tooltip>
        <template #default="scope">
          <el-tag :style="{ color: 'white', borderColor: serverityBadge.get(scope.row.serverity)?.color }" size="small"
            :color="serverityBadge.get(scope.row.serverity)?.color" disable-transitions>{{
                serverityBadge.get(scope.row.serverity)?.text
            }}
          </el-tag>
        </template>
      </el-table-column>

      <el-table-column prop="originatorType" :label="getMenuViewNameI18n('originatorType')" show-overflow-tooltip>
        <template #default="scope">
          <el-tag size="small"
            :style="{ color: 'white', borderColor: originatorTypeTAG.get(scope.row.originatorType)?.color }"
            :color="originatorTypeTAG.get(scope.row.originatorType)?.color" disable-transitions>{{
                originatorTypeTAG.get(scope.row.originatorType)?.text
            }}
          </el-tag>
        </template>
      </el-table-column>

      <el-table-column :label="getMenuViewNameI18n('operation')" show-overflow-tooltip width="200">
        <template #default="scope">
          <el-button size="small" text type="primary" v-if="
            scope.row.alarmStatus === 'Active_UnAck' ||
            scope.row.alarmStatus === 'Cleared_UnAck'
          " @click="acquireAlarm(scope.row)">确认告警
          </el-button>
          <el-button size="small" text type="primary" v-if="
            scope.row.alarmStatus === 'Active_Ack' ||
            scope.row.alarmStatus === 'Active_UnAck'
          " @click="clearAlarm(scope.row)">清除告警
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-pagination @size-change="onHandleSizeChange" @current-change="onHandleCurrentChange" class="mt15"
      :pager-count="5" :page-sizes="[10, 20, 30]" v-model:current-page="tableData.param.pageNum" background
      v-model:page-size="tableData.param.pageSize" layout="total, sizes, prev, pager, next, jumper"
      :total="tableData.total">
    </el-pagination>
  </component>
</template>

<script lang="ts" setup>

import { getAlarmList, clear, acquire,getoriginators } from "/@/api/alarm";
import { appmessage } from "/@/api/iapiresult";
import { alarmStatusOptions, serverityOptions, originatorTypeOptions, serverityBadge, alarmStatusTAG, originatorTypeTAG } from "/@/views/iot/alarms/alarmSearchOptions";
import type { TableDataRow, TableDataState } from "/@/views/iot/alarms/model";
import {getMenuViewNameI18n} from "/@/utils/other";
// 定义接口来定义对象的类型

const loading = ref(false)
const props = defineProps({
  originator: {
    type: Object,
    default: null,
  },
  wrapper: {
    type: String,
    default: "el-card",
  }
})
const tableData = reactive<TableDataState>({
  originatorOptions:[],
  originatorloading: false,
  rows: [],
  total: 0,
  loading: false,
  param: {
    pageNum: 1,
    pageSize: 10,
  },
})

const query = reactive({
  AckDateTime: "",
  ClearDateTime: "",
  StartDateTime: "",
  EndDateTime: "",
  AlarmType: "",
  alarmStatus: "-1",
  serverity: "-1",
  originatorType: "-1",
  Originator: "",
  OriginatorId:""
});
const onHandleSizeChange = (val: number) => {
  tableData.param.pageSize = val;

  getData();
};
// 分页改变
const onHandleCurrentChange = (val: number) => {
  tableData.param.pageNum = val;
  getData();
};

const getOriginators= (val:string)=>{


 getoriginators({
  OriginatorType:query.originatorType,
  originatorName:val
 }).then(res=>{

  tableData.originatorOptions=[...res.data.map(c=>{return { value: c.id, label: c.name } })]


 })
}

const clearAlarm = (row: TableDataRow) => {
  clear(row.id!).then((x: appmessage<boolean>) => {
    if (x && x.data) {
      ElMessage.success("清除成功");
      getData()
    } else {
      ElMessage.warning("清除失败:" + x.msg);
    }
  });
};
const acquireAlarm = (row: TableDataRow) => {
  acquire(row.id!).then((x: appmessage<boolean>) => {
    if (x && x.data) {
      ElMessage.success("确认成功");
      getData()
    } else {
      ElMessage.warning("确认失败" + x.msg);
    }
  });
};
const getData = async () => {

  const params = {
    offset: tableData.param.pageNum - 1,
    limit: tableData.param.pageSize,
    alarmStatus: query.alarmStatus,
    originatorId: query.OriginatorId,
    ClearDateTime: query.ClearDateTime,
    AckDateTime: query.AckDateTime,
    StartDateTime: query.StartDateTime,
    originatorType: query.originatorType,
    AlarmType: query.AlarmType,
    Name: "",
    EndDateTime: query.EndDateTime,
    OriginatorName: "",
    serverity: "-1",
  }
  if (props.originator) {
    const { id, deviceType } = props.originator
    params.OriginatorId = id
    const originatorType = originatorTypeOptions.find((x) => x.key === deviceType)
    query.originatorType = originatorType ? originatorType.value : '-1'
    params.originatorType = query.originatorType
  }
  try {
    loading.value = true
    const res = await getAlarmList(params)
    tableData.rows = res.data.rows;
    tableData.total = res.data.total;
  } catch (e) {
  }
  loading.value = false
};
// 初始化表格数据
const initTableData = () => {
  getData();
};
watch(() => props.originator, (newValue, oldValue) => {
  console.log(`%c@alarmlist:329`, 'color:black;font-size:16px;background:yellow;font-weight: bold;', newValue)
  initTableData();
})
onMounted(() => {
  initTableData();
});
</script>
