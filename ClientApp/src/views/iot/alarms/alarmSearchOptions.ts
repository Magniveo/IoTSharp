import {getMenuViewNameI18n} from "/@/utils/other";

export const alarmStatusOptions = [
	{
		value: '-1',
		label: getMenuViewNameI18n('all'),
	},
	{
		value: '0',
		label: getMenuViewNameI18n('activeUnacknowledged'),
	},
	{
		value: '1',
		label: getMenuViewNameI18n('activeAcknowledged'),
	},
	{
		value: '2',
		label: getMenuViewNameI18n('clearUnacknowledged'),
	},
	{
		value: '3',
		label: getMenuViewNameI18n('clearAcknowledged'),
	},
];

export const serverityOptions = [
	{
		value: '-1',
		label: getMenuViewNameI18n('all'),
	},
	{
		value: '0',
		label: getMenuViewNameI18n('indeterminate'),
	},
	{
		value: '1',
		label: getMenuViewNameI18n('warning'),
	},
	{
		value: '2',
		label: getMenuViewNameI18n('minor'),
	},
	{
		value: '3',
		label: getMenuViewNameI18n('important'),
	},
	{
		value: '4',
		label: getMenuViewNameI18n('error'),
	},
];

export const originatorTypeOptions = [
	{
		value: '-1',
		label: getMenuViewNameI18n('all'),
		key: 'All',
	},
	{
		value: '0',
		label: getMenuViewNameI18n('unknown'),
		key: 'Unknown',
	},
	{
		value: '1',
		label: getMenuViewNameI18n('device'),
		key: 'Device',
	},
	{
		value: '2',
		label: getMenuViewNameI18n('gateway'),
		key: 'Gateway',
	},
	{
		value: '3',
		label: getMenuViewNameI18n('asset'),
		key: 'Asset',
	},
];

export const serverityBadge = new Map([
	['Indeterminate', { text: getMenuViewNameI18n('indeterminate'), color: 'var(--el-color-info)' }],
	['Warning', { text: getMenuViewNameI18n('warning'), color: 'var(--el-color-warning)' }],
	['Minor', { text: getMenuViewNameI18n('minor'), color: 'var(--el-color-primary)' }],
	['Major', { text: getMenuViewNameI18n('important'), color: 'var(--el-color-primary-dark-2)' }],
	['Critical', { text: getMenuViewNameI18n('error'), color: 'var(--el-color-error)' }],
]);

export const alarmStatusTAG = new Map([
	['Active_UnAck', { text: getMenuViewNameI18n('activeUnacknowledged'), color: 'var(--el-color-error)' }],
	['Active_Ack', { text: getMenuViewNameI18n('activeAcknowledged'), color: 'var(--el-color-primary)' }],
	['Cleared_UnAck', { text: getMenuViewNameI18n('clearUnacknowledged'), color: 'var(--el-color-warning)' }],
	['Cleared_Act', { text: getMenuViewNameI18n('clearAcknowledged'), color: 'var(--el-color-success)' }],
]);

export const originatorTypeTAG = new Map([
	['Unknow', { text: getMenuViewNameI18n('unknown'), color: 'var(--el-color-info)' }],
	['Device', { text: getMenuViewNameI18n('device'), color: 'var(--el-color-primary)' }],
	['Gateway', { text: getMenuViewNameI18n('gateway'), color: 'var(--el-color-warning)' }],
	['Asset', { text: getMenuViewNameI18n('asset'), color: 'var(--el-color-success)' }],
]);
