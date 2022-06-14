<template>
  <div class="menu" :style="{ minWidth: show ? '221px' : '81px' }">
    <div class="menu-header">
      <div class="menu-header-icon" @click="menuAcitve"></div>
      <div class="menu-header-content" v-if="display">MISA QLTS</div>
    </div>
    <div class="menu-item">
      <div class="menu-item-icon1"></div>
      <div class="menu-item-content" v-if="display">Tổng quan</div>
    </div>
    <router-link class="menu-item" to="/asset">
      <div class="menu-item-icon2"></div>
      <div class="menu-item-content" v-if="display">Tài sản</div>
      <div class="menu-item-icon-drop" v-if="display"></div>
    </router-link>
    <router-link class="menu-item" to="/employee">
      <div class="menu-item-icon3"></div>
      <div class="menu-item-content" v-if="display">Tài sản HT-ĐB</div>
      <div class="menu-item-icon-drop" v-if="display"></div>
    </router-link>
    <div class="menu-item">
      <div class="menu-item-icon4"></div>
      <div class="menu-item-content" v-if="display">Công cụ ứng dụng</div>
      <div class="menu-item-icon-drop" v-if="display"></div>
    </div>
    <div class="menu-item">
      <div class="menu-item-icon5"></div>
      <div class="menu-item-content" v-if="display">Danh mục</div>
    </div>
    <div class="menu-item">
      <div class="menu-item-icon6"></div>
      <div class="menu-item-content" v-if="display">Tra cứu</div>
      <div class="menu-item-icon-drop" v-if="display"></div>
    </div>
    <div class="menu-item">
      <div class="menu-item-icon7"></div>
      <div class="menu-item-content" v-if="display">Báo cáo</div>
      <div class="menu-item-icon-drop" v-if="display"></div>
    </div>
    <div class="control-nemu" v-if="display">
      <div class="control-nemu-button" @click="menuAcitve"></div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      display: true, //Hiện đóng menu
      show: true, //Thay đổi độ rộng
    };
  },
  methods: {
    /*  Chức năng toggle
     *   CreatedBy: NXQuang(8/2/2022)
     */
    menuAcitve() {
      var me = this;
      //Set thời gian hiện chữ trong value
      if (this.display == false) {
        me.show = true;
        setTimeout(function () {
          me.display = true;
        }, 500);
      }
      //Đóng value
      else this.show = this.display = false;
    },
  },
};
</script>

<style scoped>
@import url("../../style/layout/Menu.css");
</style>
