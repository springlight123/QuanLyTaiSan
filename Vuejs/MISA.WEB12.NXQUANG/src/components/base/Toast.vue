<template>
  <div class="toast" :style="{ left: isDisplay ? '85%' : '100%' }">
    <div class="icon"></div>
    <div class="toast-content" v-if="type == 'save'">
      Lưu dữ liệu thành công
    </div>
    <div class="toast-content" v-if="type == 'delete'">
      Xóa dữ liệu thành công
    </div>
  </div>
</template>

<script>
export default {
  props: {
    type: String,
  },
  data() {
    return {
      isDisplay: false,
    };
  },
  methods: {
    show() {
      let me = this;
      this.isDisplay = true;
      setTimeout(function () {
        me.isDisplay = false;
      }, 2500);
    },
  },
};
</script>

<style scoped>
@import url("../../style/base/Toast.css");
</style>
