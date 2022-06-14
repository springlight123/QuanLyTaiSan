<template>
  <div class="drop-down" @click="displayDrop" :class="{ border: isDisplay }">
    <div class="drop-down-content" v-show="isDisplay" @click="displayDrop">
      <!-- Tạo các item -->
      <div
        class="drop-down-item"
        v-for="(dropContent, index) of dropContents"
        :key="dropContent"
        @click="chooseDrop(dropContent, index)"
        :class="[index == isChoose ? 'chooseItem' : '']"
      >
        {{ dropContent }}
      </div>
    </div>
    <div class="drop-text">{{ dropChoose }}</div>
  </div>
</template>

<script>
export default {
  props: {
    dropContents: Array, //Mảng các item truyền từ cha
  },
  data() {
    return {
      isDisplay: false, //kiểm tra ẩn hiện dropdown
      isChoose: 0, //kiểm tra xem item có được chọn k
      dropChoose: this.dropContents[0], //item đã được chọn
    };
  },
  methods: {
    /*    Ẩn hiện mục item
     *   CreatedBy: NXQuang(7/2/2022)
     */
    displayDrop() {
      this.isDisplay = !this.isDisplay;
    },
    /*   Chọn 1 item
     *   CreatedBy: NXQuang(7/2/2022)
     */
    chooseDrop(dropContent, index) {
      //Khiến item đã chọn có nền màu xanh
      this.isChoose = index;
      //ĐÓNG bảng item
      this.isDisplay = !this.isDisplay;
      //Thay doi dropChoose thanh gia tri cua item da chon
      this.dropChoose = dropContent;
      //Truyen dropChoose den component cha
      this.$emit("ondrop", this.dropChoose);
    },
    /*   Hiện border khi focus
     *   CreatedBy: NXQuang(7/2/2022)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.isDisplay = false;
      }
    },
  },
  /*   Gán hàm close cho component
   *   CreatedBy: NXQuang(7/2/2022)
   */
  created() {
    window.addEventListener("click", this.close);
  },
  /*   Hủy hàm close khi hủy Component
   *   CreatedBy: NXQuang(7/2/2022)
   */
  beforeDestroy() {
    window.removeEventListener("click", this.close);
  },
};
</script>

<style scoped>
@import url("../../style/base/DropDown.css");
</style>
