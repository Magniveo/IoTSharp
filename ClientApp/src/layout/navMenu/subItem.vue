<template>
  <template v-for="val in chils">
    <el-sub-menu :index="val.path" :key="val.path" v-if="val.children && val.children.length > 0">
      <template #title>
        <!--				<SvgIcon :name="val.meta.icon" />-->
        <el-icon class="z-menu-icon">
          <component :is="menuIconList[val.name]"></component>
        </el-icon>
        <span>{{ getMenuViewNameI18n(val.name)  }} </span>
      </template>
      <!--			<sub-item :chil="val.children" />-->
    </el-sub-menu>
    <template v-else>
      <el-menu-item :index="val.path" :key="val.path">
        <template v-if="!val.meta.isLink || (val.meta.isLink && val.meta.isIframe)">
          <!--					<SvgIcon :name="val.meta.icon" />-->
          <el-icon class="z-menu-icon" style="margin-right: 10">
            <component :is="menuIconList[val.name]"></component>
          </el-icon>
          <!--         *  // 在这里修改子菜单-->
          <span >{{ getMenuViewNameI18n(val.name) }}</span>
        </template>
        <template v-else>
          <a :href="val.meta.isLink" target="_blank" rel="opener" class="w100">
            <SvgIcon :name="val.meta.icon"/>
            {{ getMenuViewNameI18n(val.name) }}
          </a>
        </template>
      </el-menu-item>
    </template>
  </template>
</template>

<script lang="ts">
import {computed, defineComponent} from 'vue';
import {menuIconList} from "/@/layout/navMenu/menu-icons-config.js";
import {getMenuViewNameI18n} from "/@/utils/other";

export default defineComponent({
  name: 'navMenuSubItem',
  methods: {getMenuViewNameI18n},
  props: {
    chil: {
      type: Array,
      default: () => [],
    },
  },
  setup(props) {
    // 获取父级菜单数据
    const chils = computed(() => {
      return <any>props.chil;
    });
    return {
      chils, menuIconList
    };
  },
});
</script>
