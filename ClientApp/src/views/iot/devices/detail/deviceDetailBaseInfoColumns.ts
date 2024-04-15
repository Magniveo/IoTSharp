import { dict } from '@fast-crud/fast-crud';
import {getTagViewNameI18n} from "/@/utils/other";

export const deviceDetailBaseInfoColumns = {
	name: {
		title: getTagViewNameI18n('deviceName'),
		type: 'button',
	},
	deviceType: {
		title: getTagViewNameI18n('deviceType'),
		type: 'dict-select',
		dict: dict({
			data: [
				{ value: 'Gateway', label: getTagViewNameI18n('Gateway') },
				{ value: 'Device', label: getTagViewNameI18n('Device'), color: 'warning' },
			],
		}),
	},

	active: {
		title: getTagViewNameI18n('activeStatus'),
		type: 'dict-switch',
		dict: dict({
			data: [
				{ value: true, label: getTagViewNameI18n('activity') },
				{ value: false, label: getTagViewNameI18n('silence'), color: 'danger' },
			],
		}),
	},
	lastActivityDateTime: {
		title: getTagViewNameI18n('lastAcivityTime'),
		type: 'text',
	},
	identityType: {
		title:getTagViewNameI18n('authenticationMethod'),
		type: 'dict-select',
		dict: dict({
			data: [
				{ value: 'AccessToken', label: 'AccessToken' },
				{ value: 'X509Certificate', label: 'X509Certificate' },
			],
		}),
	},
	identityId: {
		title: 'Token',
		type: 'text',
	},
	timeout: {
		title: getTagViewNameI18n('timeOut'),
		type: 'text',
	},
};
