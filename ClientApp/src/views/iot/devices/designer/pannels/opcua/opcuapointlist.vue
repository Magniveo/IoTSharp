<template>
	<div>
		<el-form ref="tableRulesRef" :model="state.tableData" size="small">
			<el-table :data="state.tableData.data" table-layout="auto">
				<el-table-column v-for="(item, index) in state.tableData.header" :key="index" show-overflow-tooltip
					:prop="item.prop" :width="item.width" :label="item.label">
					<!-- <template v-slot:header>
				  <span v-if="item.isRequired" class="color-danger">*</span>
				  <span class="pl5">{{ item.label }}</span>
				  <el-tooltip
					v-if="item.isTooltip"
					effect="dark"
					content="这是tooltip"
					placement="top"
				  >
					<i class="iconfont icon-quanxian" />
				  </el-tooltip>
				</template> -->
					<template v-slot="scope">
						<el-form-item style="margin: 0" :prop="`data.${scope.$index}.${item.prop}`" :rules="[
	{
		required: item.isRequired,
		message: getTagViewNameI18n('canNotBeEmpty'),
		trigger: `${item.type}` == 'input' ? 'blur' : 'change',
	},
]">

							<el-input-number v-if="item.type === 'number'" v-model="scope.row[item.prop]" />
							<el-switch v-if="item.type === 'switch'" v-model="scope.row[item.prop]" />

							<el-select v-if="item.type === 'select' && item.prop == 'dataType'"
								v-model="scope.row[item.prop]" :placeholder="getTagViewNameI18n('pleaseSelect')">
								<el-option v-for="sel in state.tableData.datatypes" :key="sel.id" :label="sel.label"
									:value="sel.value" />
							</el-select>
							<el-select v-if="item.type === 'select' && item.prop == 'dataCatalog'"
								v-model="scope.row[item.prop]" :placeholder="getTagViewNameI18n('pleaseSelect')">
								<el-option v-for="sel in state.tableData.datacatalogs" :key="sel.id" :label="sel.label"
									:value="sel.value" />
							</el-select>
							<el-date-picker v-else-if="item.type === 'date'" v-model="scope.row[item.prop]" type="date"
								:placeholder="" style="width: 100%" />
							<el-input v-else-if="item.type === 'input'" v-model="scope.row[item.prop]"
								:placeholder="getTagViewNameI18n('pleaseEnterTheContent')" />
							<el-input v-else-if="item.type === 'dialog'" v-model="scope.row[item.prop]" readonly
								:placeholder="getTagViewNameI18n('pleaseEnterTheContent')">
								<template v-slot:suffix>
									<i class="iconfont icon-shouye_dongtaihui" />
								</template>
							</el-input>
						</el-form-item>
					</template>
				</el-table-column>

				<el-table-column>
					<template #default="scope">
						<el-button text type="primary" @click.prevent="deleterow(scope.row)">{{ getTagViewNameI18n('delete') }}
						</el-button>
					</template></el-table-column>
			</el-table>
		</el-form>
		<el-row class="flex mt15">
			<div class="flex-margin">
				<!-- <el-button size="default" type="success" @click="onValidate">验证</el-button> -->
				<el-button size="default" type="primary" @click="onAddRow">{{ getTagViewNameI18n('add') }}</el-button>
				<el-button size="default" type="primary" @click="save">{{ getTagViewNameI18n('save') }}</el-button>
			</div>
		</el-row>


	</div>
</template>
  
<script lang="ts" setup>
import { reactive, ref } from "vue";
import { v4 as uuidv4, NIL as NIL_UUID } from "uuid";
import { ElMessage } from "element-plus";

import { editProduceDictionary, getProduceDictionary } from "/@/api/produce";
import { datacatalogs, datatypes, funcodes } from "../../models/constants";
import { opcuamapping } from "../../models/opcuamapping";
import {getTagViewNameI18n} from "/@/utils/other";
interface TableHeader {
	prop: string;
	width: string | number;
	label: string;
	isRequired?: boolean;
	isTooltip?: boolean;
	type: string;
}
interface TableRulesState {
	deviceid: string;
	drawer: boolean;
	dialogtitle: string;
	tableData: {
		data: opcuamapping[];
		header: TableHeader[];
		datatypes: any[];
		datacatalogs: any[];

	};
}

const props = defineProps({
	modelValue: {
		type: Object,
		default: {},
	},

});

const emit = defineEmits(["close", "submit"]);
const tableRulesRef = ref();
const state = reactive<TableRulesState>({
	deviceid: "",
	drawer: false,
	dialogtitle: "OpcUA点位修改",
	tableData: {
		data: props.modelValue.node.bizdata.mappings,
		header: [
			{
				prop: "dataName",
				width: "",
				label: "采集项名称",
				isRequired: false,
				type: "input",
			},
			{
				prop: "dataType",
				width: "",
				label: "数据类型",
				isRequired: false,
				type: "select",
			},

			{
				prop: "dataCatalog",
				width: "",
				label: "数据分类",
				isRequired: false,
				type: "select",
			},
			{
				prop: "nodeId",
				width: "",
				label: "功能",
				isRequired: false,
				type: "select",
			},

			{
				prop: "dataFormat",
				width: "90px",
				label: "数据格式",
				isRequired: false,
				type: "input",
			},
			{
				prop: "codePage",
				width: "",
				label: "字符串编码",
				isRequired: false,
				type: "number",
			},

		],
		datatypes: [...funcodes.values()],
		datacatalogs: [...datatypes.values()],

	},
});



watch(() => state.tableData, async () => {

  console.log(state.tableData)

})


onMounted(async () => {
	console.log([...funcodes.values()])
});
const openDialog = (deviceid: string) => {
	state.deviceid = deviceid;
	state.drawer = true;
};
// 关闭弹窗
const closeDialog = () => {
	state.drawer = false;
};

// 验证
const onValidate = () => {
	if (state.tableData.data.length <= 0) return ElMessage.warning("请先点击增加一行");
	tableRulesRef.value.validate((valid: any) => {
		if (!valid) return ElMessage.warning("表格项必填未填");
		ElMessage.success("全部验证通过");
	});
};

// 新增一行
const onAddRow = () => {
	props.modelValue.node.bizdata.mappings.push({
		_id: uuidv4(),
		id: NIL_UUID,
		code: 0,
		dataName: "",
		dataType: "",
		dataCatalog: "",
		funCode: "",
		address: 0,
		length: 0,
		dataFormat: "",
		codePage: 0,

	})
};
const deleterow = (row: opcuamapping) => {
	props.modelValue.node.bizdata.mappings = props.modelValue.node.bizdata.mappings.filter((c) => c._id !== row._id)
};
const save = async () => {
	emit("submit", {
		namespace: 'opcualistchanged',
		data: props.modelValue,
	});
};

defineExpose({
	openDialog,
});
</script>
  