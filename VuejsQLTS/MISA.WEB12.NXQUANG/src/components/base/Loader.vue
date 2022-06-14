<template>
  <div class="outer-loader" v-if="isDisplay">
    <div class="loader"></div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isDisplay: false, //An hien loader
    };
  },
};
</script>

<style scoped>
@import url("../../style/base/Loader.css");
</style>
