<template>
  <input type="checkbox" class="checkbox" @click="checkboxEvent" />
</template>

<script>
export default {
  methods: {
    /*  Thực hiện phương thức onCheckBox khi click
     *   CreatedBy: NXQuang(6/2/2022)
     */
    checkboxEvent() {
      this.$emit("onCheckBox");
    },
  },
};
</script>

<style scoped>
@import url("../../style/base/CheckBox.css");
</style>
