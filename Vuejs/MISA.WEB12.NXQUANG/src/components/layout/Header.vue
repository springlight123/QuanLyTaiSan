<template>
  <div class="header">
    <div class="header-content">Danh sách tài sản</div>
    <div class="infor-user">
      <div style="font-size: 1.6rem">Sở tài chính</div>
      <div class="input-year">
        <label style="font-size: 1.3rem; margin-left:10px">Năm</label>
        <div class="year">
          <div class="full-year">{{year}}</div>
          <div class="icon-year">
            <div class="icon-up-header" @click="upYear"></div>
             <div class="icon-down-header" @click="downYear"></div>
          </div>
        </div>
      </div>
      <div class="header-icon icon-bell"></div>
      <div class="header-icon icon-select"></div>
      <div class="header-icon icon-question"></div>
      <div class="header-icon icon-avatar"></div>
      <div class="header-icon icon-setting"></div>
    </div>
  </div>
</template>

<script>
export default {
   data() {
     return {
       year: ""
     };
   },
      created() {
        this.year = new Date().getFullYear();
    },
    methods:{
      upYear(){
         this.year=this.year+1
      },
      downYear(){
         this.year=this.year-1
      }
    }
};
</script>

<style scoped>
@import url("../../style/layout/Header.css");
</style>
