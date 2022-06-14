<template>
  <div class="button" @click="buttonEvent">{{ btName }}</div>
</template>

<script>
export default {
  props: {
    btName: String, //Tên của button
  },
  methods: {
    /*   Thực hiện phương thức onclick khi click
     *   CreatedBy: NXQuang(6/2/2022)
     */
    buttonEvent() {
      this.$emit("onclick");
    },
  },
};
</script>

<style scoped>
@import url("../../style/base/Button.css");
</style>
