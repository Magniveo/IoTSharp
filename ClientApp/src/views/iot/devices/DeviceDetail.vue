<template>
  <div>
    <el-drawer v-model="drawer" :title="dialogTitle" size="70%">
      <el-tabs v-model="activeTabName" class="demo-tabs" stretch>
        <el-tab-pane :label="getMenuViewNameI18n('details')" name="basic">
          <div class="z-tab-container">

            <el-button :icon="RefreshLeft" circle  class="btn-refresh el-button--primary" @click="reloadbaseinfo" />

            <AdvancedKeyValue
                :obj="deviceRef"
                :config="columns"
                :hide-key-list="['owner', 'identityValue', 'tenantName', 'customerName', 'tenantId', 'customerId']"
                :label-width="160">
              <template #footer v-if="deviceRef.identityType==='X509Certificate'">
                <div class="z-row">
                  <div class="z-key" style="width: 160px">{{ getMenuViewNameI18n('certificate') }}</div>
                  <div class="z-value"><ElButton @click="downloadCert">{{ getMenuViewNameI18n('downloadCertificate') }}</ElButton></div>
                </div>
              </template>
            </AdvancedKeyValue>

          </div>
        </el-tab-pane>
        <el-tab-pane :label="getMenuViewNameI18n('properties')" name="props">
          <div class="z-tab-container">
            <DeviceDetailProps :deviceId="deviceRef.id"></DeviceDetailProps>
          </div>

        </el-tab-pane>
        <el-tab-pane :label="getMenuViewNameI18n('telemetry')" name="telemetry">
          <div class="z-tab-container">
            <DeviceDetailTelemetry :deviceId="deviceRef.id"></DeviceDetailTelemetry>
          </div>
        </el-tab-pane>
        <el-tab-pane :label="getMenuViewNameI18n('historyTelemtry')" name="telemetryHistory" :lazy="true">
          <div class="z-tab-container">
            <DeviceDetailTelemetryHistory :deviceId="deviceRef.id"></DeviceDetailTelemetryHistory>
          </div>
        </el-tab-pane>
        <el-tab-pane :label="getMenuViewNameI18n('alarm')" name="alarm">
          <div class="z-tab-container">
            <alarmlist :originator="deviceRef" wrapper="div"></alarmlist>
          </div>
        </el-tab-pane>
        <el-tab-pane :label="getMenuViewNameI18n('rules')" name="rules">
          <div class="z-tab-container">
            <DeviceDetailRules :deviceId="deviceRef.id"></DeviceDetailRules>
          </div>
        </el-tab-pane>
        <el-tab-pane :label="getMenuViewNameI18n('rulesHistory')" name="rulesHistory">
          <div class="z-tab-container">
            <flowevents :creator="deviceRef.id" :creatorname="deviceRef.name"  wrapper="div"></flowevents>
          </div>
        </el-tab-pane>

        <el-tab-pane :label="getMenuViewNameI18n('map')" name="map">
          <div class="z-tab-container">
        <BMap :deviceId="deviceRef.id"></BMap>
          </div>
        </el-tab-pane>
      </el-tabs>
    </el-drawer>
  </div>
</template>
<script lang="ts" setup>
import { RefreshLeft } from '@element-plus/icons-vue'
import { deviceDetailBaseInfoColumns } from '/@/views/iot/devices/detail/deviceDetailBaseInfoColumns'
import AdvancedKeyValue from "/@/components/AdvancedKeyValue/AdvancedKeyValue.vue";
import DeviceDetailProps from "/@/views/iot/devices/detail/DeviceDetailProps.vue";
import DeviceDetailRules from "/@/views/iot/devices/detail/DeviceDetailRules.vue";
import DeviceDetailTelemetry from "/@/views/iot/devices/detail/DeviceDetailTelemetry.vue";
import DeviceDetailTelemetryHistory from "/@/views/iot/devices/detail/DeviceDetailTelemetryHistory.vue";
import Alarmlist from "/@/views/iot/alarms/alarmlist.vue";
import Flowevents from "/@/views/iot/rules/flowevents.vue";
import { deviceApi } from "/@/api/devices";
import { downloadByData } from "/@/utils/download";
import BMap  from "/@/views/iot/devices/detail/maps/bmap/BMap.vue";
import {getMenuViewNameI18n} from "/@/utils/other";
const drawer = ref(false);
const dialogTitle = ref(`设备详情`);
const activeTabName = ref('basic')
const deviceRef = ref()
const columns = deviceDetailBaseInfoColumns



const openDialog = (device: any) => {





  drawer.value = true
  deviceRef.value = Object.assign({},device )
  // Object.assign(deviceRef, device)
  dialogTitle.value = `${deviceRef.value.name}设备详情`
};



const reloadbaseinfo= async () =>{
 var _dev=await deviceApi().getdevcie(deviceRef.value.id);
 deviceRef.value = Object.assign({},_dev.data )
 dialogTitle.value = `${deviceRef.value.name}设备详情`
}
const downloadCert = async () =>{
  const res = await deviceApi().downloadCertificates(deviceRef.value.id)
  downloadByData(res, `${deviceRef.value.id}.zip`)
}
defineExpose({
  openDialog,
});

</script>
<style lang="scss" scoped>
.z-tab-container {
  padding: 0 16px 16px;
}.btn-refresh {
  float:right;
}
</style>
