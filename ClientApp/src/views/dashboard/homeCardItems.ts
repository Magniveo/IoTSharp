import deviceIcon from '~icons/carbon/iot-platform'
import telemetry from '~icons/carbon/ibm-cloud-pak-data'
import event from '~icons/carbon/ibm-cloud-event-streams'
import warning from '~icons/ic/round-warning'
import userIcon from '~icons/ic/baseline-supervisor-account'
import product from '~icons/ic/outline-category'
import rule from '~icons/carbon/flow-modeler'
import assets from '~icons/ic/outline-devices-other'
import {getTagViewNameI18n} from "/@/utils/other";

export const homeCardItemsConfig = [
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('allDevices'),
        icon: deviceIcon,
        iconBackgroundColor: '#4945FF',
    },
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('online'),
        icon: deviceIcon,
        iconBackgroundColor: '#10b981',
    },
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('Today\'s attributes'),
        icon: telemetry,
        iconBackgroundColor: '#002766',
    },
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('Today\'s events'),
        icon: event,
        iconBackgroundColor: '#0050B3',
    },
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('Alarm equipment'),
        icon: warning,
        iconBackgroundColor: '#FA9D14',
    },
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('user'),
        icon: userIcon,
        iconBackgroundColor: '#0091FF',
    },
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('product'),
        icon: product,
        iconBackgroundColor: '#32C5FF',
    },
    {
        zValue: '-1',
        zKey: getTagViewNameI18n('rules'),
        icon: rule,
        iconBackgroundColor: '#6DD400',
    },
];
