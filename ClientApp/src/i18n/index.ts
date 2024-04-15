import { createI18n } from 'vue-i18n';
import pinia from '/@/stores/index';
import { storeToRefs } from 'pinia';
import { useThemeConfig } from '/@/stores/themeConfig';
import zhcnLocale from "element-plus/dist/locale/zh-cn.mjs";
import enLocale from "element-plus/dist/locale/en.mjs";
import ruLocale from "element-plus/dist/locale/ru.mjs";
import nextZhcn from '/@/i18n/lang/zh-cn';
import nextEn from '/@/i18n/lang/en';
import nextRu from '/@/i18n/lang/ru';
import nextZhtw from '/@/i18n/lang/zh-tw';
import pagesLoginZhcn from '/@/i18n/pages/login/zh-cn';
import pagesLoginEn from '/@/i18n/pages/login/en';
import pagesLoginRu from '/@/i18n/pages/login/ru';
import pagesLoginZhtw from '/@/i18n/pages/login/zh-tw';
import pagesFormI18nZhcn from '/@/i18n/pages/formI18n/zh-cn';
import pagesFormI18nEn from '/@/i18n/pages/formI18n/en';
import pagesFormI18nRu from '/@/i18n/pages/formI18n/ru';
import pagesFormI18nZhtw from '/@/i18n/pages/formI18n/zh-tw';

// 定义语言国际化内容
/**
 * 说明：
 * /src/i18n/lang 下的 ts 为框架的国际化内容
 * /src/i18n/pages 下的 ts 为各界面的国际化内容
 */
const messages = {
	[zhcnLocale.name]: {
		...zhcnLocale,
		message: {
			...nextZhcn,
			...pagesLoginZhcn,
			...pagesFormI18nZhcn,
		},
	},
	[enLocale.name]: {
		...enLocale,
		message: {
			...nextEn,
			...pagesLoginEn,
			...pagesFormI18nEn,
		},
	},
	[ruLocale.name]: {
		...ruLocale,
		message: {
			...nextRu,
			...pagesLoginRu,
			...pagesFormI18nRu,
		},
	},
};

// 读取 pinia 默认语言
const stores = useThemeConfig(pinia);
const { themeConfig } = storeToRefs(stores);

// 导出语言国际化
// https://vue-i18n.intlify.dev/guide/essentials/fallback.html#explicit-fallback-with-one-locale
export const i18n = createI18n({
	legacy: false,
	silentTranslationWarn: true,
	missingWarn: false,
	silentFallbackWarn: true,
	fallbackWarn: false,
	locale: themeConfig.value.globalI18n,
	fallbackLocale: ruLocale.name,
	messages,
});
