<template>
  <input
    class="input"
    v-bind:value="value"
    v-on:input="inputEvent"
    v-on:keydown.enter="keydownEvent"
    :maxlength="max"
  />
</template>

<script>
export default {
  props: {
    value: String, //Gía trị của compot cha truyền vào
    max: String, //Kí tự max được nhập
  },
  methods: {
    /* Thực hiện binding 2 chiều giữa 2 component và thực hiện sự kiện onkeydown
     *   CreatedBy: NXQuang(7/2/2022)
     */
    inputEvent() {
      this.$emit("input", event.target.value);
    },
    keydownEvent(){
 this.$emit("onkeydown", event.target.value);
    }
  },
};
</script>

<style scoped>
@import url("../../style/base/Input.css");
</style>
