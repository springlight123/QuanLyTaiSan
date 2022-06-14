<template>
  <div class="combo-box" :style="{ borderColor: isFocus }">
    <input
      class="input"
      v-model="value"
      v-on:input="onInput"
      :placeholder="textHolder"
      @focus="onFocus"
    />
    <div class="combox-box-icon" @click="displayComb"></div>
    <!-- Tạo các item trong component FormAsset -->
    <div class="combo-content" v-show="isDisplay" v-if="type == 'form'">
      <div
        class="combo-item combo-item-form"
        v-show="
          comboContent.toLowerCase().indexOf(valueSearch.toLowerCase()) != -1
        "
        v-for="(comboContent, index) of comboContents.code"
        :key="index"
        @click="chooseComb(index, comboContent)"
        :class="[index == isChoose ? 'chooseItem' : '']"
      >
        <div class="combo-item-infor" style="min-width: 80px">
          {{ comboContents.code[index] }}
        </div>
        <div class="combo-item-infor">{{ comboContents.name[index] }}</div>
      </div>
    </div>
    <!-- Tạo các item trong component content  -->
    <div class="combo-content" v-show="isDisplay" v-else-if="type == 'content'">
      <div
        class="combo-item"
        v-show="
          comboContent.toLowerCase().indexOf(valueSearch.toLowerCase()) != -1
        "
        v-for="(comboContent, index) of comboContents.name"
        :key="index"
        @click="chooseComb(index, comboContent)"
        :class="[index == isChoose ? 'chooseItem' : '']"
      >
        {{ comboContent }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    textHolder: String, //props placeholder
    comboContents: Object, //Object chứa các item
    type: String, //Loại combo dùng cho các trường họp khác nhau
    valueEdit: {
      type: String,
      default: "",
    }, //Value khi chuyền dữ liệu để sửa, copy asset
  },
  data() {
    return {
      isDisplay: false, //kiểm tra ẩn hiện combobox
      isChoose: -1, //kiểm tra item có đang được chọn
      isFocus: false, //Kiểm tra item có đang được focus
      valueSearch: "", //Value để filter
      value: "", //
    };
  },
  methods: {
    /*   Ân hiện item
     *   CreatedBy: NXQuang(6/2/2022)
     */
    displayComb() {
      this.isDisplay = !this.isDisplay;
      if (this.isDisplay == true) this.isFocus = "#1aa4c8";
      else this.isFocus = "#bbbbbb";
    },
    /*   Chọn item muốn chọn, thay đổi value cảu trường input thành thông tin của item đã chọn
     *   CreatedBy: NXQuang(6/2/2022)
     */
    chooseComb(index, comboContent) {
      //Add class cho item da chon
      this.isChoose = index;
      //ĐÓNG bảng item
      this.isDisplay = false;
      //Bordẻ thành màu xám
      this.isFocus = "#bbbbbb";
      //Trả về giá trị của input để rằng buộc dữ liệu 2 chiều với component outer-employee
      this.value = comboContent;
      //Thay đổi value dùng để filter bằng với value
      this.valueSearch = this.value;
      //Thực hiện hàm onComb tại component cha
      this.$emit("onComb", comboContent);
    },
    /*  Khi thay đổi dữ liệu của trường input bằng sự kiện input, thay đổi item đang chọn
     *   CreatedBy: NXQuang(6/2/2022)
     */
    onInput() {
      //Nếu value rỗng, không có item đang chọn
      if (this.value == "") {
        this.isChoose = -1;
        //Thực hiện hàm onComb tại component cha
        this.$emit("onComb", this.value);
      }
      //Thay đổi value dùng để filter bằng với value
      this.valueSearch = this.value;
    },
    /*   Đóng bảng item
     *   CreatedBy: NXQuang(6/2/2022)
     */
    close(e) {
      //Nếu ấn ra ngoài, đóng bảng item và borer thành màu xám
      if (!this.$el.contains(e.target)) {
        this.isDisplay = false;
        this.isFocus = "#bbbbbb";
      }
    },
    /*   Hiện border khi focus
     *   CreatedBy: NXQuang(6/2/2022)
     */
    onFocus() {
      //Thêm borer màu xanh
      this.isFocus = "#1aa4c8";
    },
  },
  /*   Gán hàm close cho component
   *   CreatedBy: NXQuang(6/2/2022)
   */
  created() {
    window.addEventListener("click", this.close);
  },
  /*   Hủy hàm close khi hủy Component
   *   CreatedBy: NXQuang(6/2/2022)
   */
  beforeDestroy() {
    window.removeEventListener("click", this.close);
  },
  /*   Theo dõi value khi nhận value do truyền asset khi sửa, copy
   *   CreatedBy: NXQuang(6/2/2022)
   */
  watch: {
    valueEdit(value) {
      //value bằng value
      this.value = value;
      //value để filter bằng value
      this.valueSearch = value;
    },
  },
};
</script>

<style scoped>
@import url("../../style/base/ComboxBox.css");
</style>
