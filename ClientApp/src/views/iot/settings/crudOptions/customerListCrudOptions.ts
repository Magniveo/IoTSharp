import { customerApi } from '/@/api/customer';
import _ from 'lodash-es';
import { TableDataRow } from '../model/tenantListModel';
import { ElMessage } from 'element-plus';
import { useRouter } from 'vue-router';
import {getTagViewNameI18n} from "/@/utils/other";
export const createCustomerListCrudOptions = function ({ expose }, tenantId) {
	const router = useRouter();
	let records: any[] = [];
	const FsButton = {
		link: true,
	};
	const customSwitchComponent = {
		activeColor: 'var(--el-color-primary)',
		inactiveColor: 'var(el-switch-of-color)',
	};
	const pageRequest = async (query) => {
		let {
			form: { name },
			page: { currentPage: currentPage, pageSize: limit },
		} = query;
		let offset = currentPage === 1 ? 0 : currentPage - 1;
		const res = await customerApi().customerList({ name, limit, offset, tenantId });
		return {
			records: res.data.rows,
			currentPage: currentPage,
			pageSize: limit,
			total: res.data.total,
		};
	};
	const editRequest = async ({ form, row }) => {
		form.id = row.id;
		try {
			await customerApi().putCustomer({
				...form,
				tenantId,
			});
			return form;
		} catch (e) {
			ElMessage.error(e.response.msg);
		}
	};
	const delRequest = async ({ row }) => {
		try {
			await customerApi().deleteCustomer(row.id);
			_.remove(records, (item: TableDataRow) => {
				return item.id === row.id;
			});
		} catch (e) {
			ElMessage.error(e.response.msg);
		}
	};

	const addRequest = async ({ form }) => {
		try {
			await customerApi().postCustomer({
				...form,
				tenantId,
			});
			records.push(form);
			return form;
		} catch (e) {
			ElMessage.error(e.response.msg);
		}
	};
	return {
		crudOptions: {
			request: {
				pageRequest,
				delRequest,
				addRequest,
				editRequest,
			},
			table: {
				border: false,
			},
			form: {
				labelWidth: '80px',
			},
			search: {
				show: true,
			},
			rowHandle: {
				width: 320,
				buttons: {
					view: {
						icon: 'View',
						...FsButton,
						show: false,
					},
					device: {
						text: getTagViewNameI18n('devicemnt'),
						title: getTagViewNameI18n('devicemnt'),
						icon: 'Cpu',
						order: 1,
						type: 'default',
						...FsButton,
						click: (e) => {
							router.push({
								path: '/iot/devices/devicelist',
								query: {
									id: e.row.id,
								},
							});
						},
					},
					custom: {
						text: getTagViewNameI18n('usermnt'),
						title: getTagViewNameI18n('usermnt'),
						icon: 'User',
						order: 1,
						type: 'info',
						...FsButton,
						click: (e) => {
							router.push({
								path: '/iot/settings/userlist',
								query: {
									id: e.row.id,
								},
							});
						},
					},
					edit: {
						icon: 'EditPen',
						...FsButton,
						order: 2,
					},
					remove: {
						icon: 'Delete',
						...FsButton,
						order: 3,
					},
				},
			},
			columns: {
				name: {
					title: getTagViewNameI18n('keyName'),
					type: 'text',
					column: { width: 200 },
					search: { show: true },
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				email: {
					title: getTagViewNameI18n('mail'),
					type: 'text',
					column: { width: 180 },
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				phone: {
					title: getTagViewNameI18n('phone'),
					column: { width: 150 },
					type: 'text',
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				country: {
					title: getTagViewNameI18n('country'),
					column: { width: 80 },
					type: 'text',
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				province: {
					title: getTagViewNameI18n('province'),
					type: 'text',
					column: { width: 80 },
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				city: {
					title: getTagViewNameI18n('city'),
					type: 'text',
					column: { width: 100 },
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				street: {
					title: getTagViewNameI18n('street'),
					column: { width: 180 },
					type: 'text',
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				address: {
					title: getTagViewNameI18n('address'),
					column: { width: 180 },
					type: 'text',
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
				zipCode: {
					title: getTagViewNameI18n('zipCode'),
					column: { width: 150 },
					type: 'text',
					addForm: {
						show: true,
						component: customSwitchComponent,
					},
					editForm: {
						show: true,
						component: customSwitchComponent,
					},
				},
			},
		},
	};
};
