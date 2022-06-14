<template>
  <div class="content">
    <div class="content-top">
      <div class="content-field">
        <Input
          type="search"
          class="input-icon"
          :placeholder="resources.holderInput.holderSearch"
          style="margin-right: 10px"
          @onkeydown="search"
        />
        <ComboBox
          :textHolder="resources.holderInput.holderCater"
          :comboContents="category"
          @onComb="changeCater"
          type="content"
        />
        <ComboBox
          :textHolder="resources.holderInput.holderDepar"
          :comboContents="department"
          @onComb="changeDepar"
          type="content"
        />
      </div>
      <div style="display: flex">
        <Button
          class="button button-no-icon"
          btName="+ Thêm tài sản"
          @onclick="add"
        />
        <Button class="button button-copy" />
        <Button class="button button-delete" @onclick="showDelete" />
      </div>
    </div>
    <Table :isFilter="isFilter" ref="tableDelete" />
  </div>
</template>

<script>
import Resources from '../../js/Resources.js'
import Table from "../base/Table.vue";
import Input from "../base/Input.vue";
import ComboBox from "../base/ComboBox.vue";
import Button from "../base/Button.vue";
import axios from "axios";
import { EventBus } from "@/bus.js";
export default {
  components: {
    Table,
    Input,
    Button,
    ComboBox,
  },
  data() {
    return {
      isLoad: false, //Tín hiệu để Table reload dữ liệu
      department: {
        name: [],
        code: [],
        id: [],
      }, //Thông tin combobox phòng ban
      category: {
        name: [],
        code: [],
        id: [],
      }, //Thông tin combobox vị trí
      isFilter: {
        FilterDepar: "",
        FilterCater: "",
      }, //Lọc theo phòng ban và vị trí
      isDelete: true, //Tín hiệu đã xóa
      resources:{}
    };
  },
  methods: {
    /*   Sự kiện hiện form thêm mới dữ kiệu
     *   CreatedBy: NXQuang(7/2/2022)
     */
    add() {
      //Truyền mã nhân viên mới lên form
      let newCode = this.$refs.tableDelete.newCode;
      EventBus.$emit("assetDisplay", newCode);
    },
    /*  Hiện form thông báo xóa
     *   CreatedBy: NXQuang(7/2/2022)
     */
    showDelete() {
      this.$refs.tableDelete.showDelete();
    },
    /*   Truyền tên thể loại đã chọn để filter
     *   CreatedBy: NXQuang(7/2/2022)
     */
    changeCater(comboContent) {
      this.isFilter.FilterCater = comboContent;
    },
    /*   Truyền tên phòng ban đã chọn để filter
     *   CreatedBy: NXQuang(7/2/2022)
     */
    changeDepar(comboContent) {
      this.isFilter.FilterDepar = comboContent;
    },
    /*  Truyền ma tài sản đến component table để reload dữ liệu
     *   CreatedBy: NXQuang(7/2/2022)
     */
    search() {
      EventBus.$emit("isSearch", event.target.value);
    },
  },
  created() {
    this.resources=Resources
    var me = this;
    try {
      //Gọi api phòng ban
      axios
        .get("http://localhost:59636/api/v1/Departments")
        .then(function (res) {
          for (let i of res.data) {
            //Push mã phòng ban vào mảng truyền xuống combobox
            me.department.code.push(i.departmentCode);
            //Push tên phòng ban vào mảng truyền combobox
            me.department.name.push(i.departmentName);
            //Push id phòng ban vào mảng truyền combobox
            me.department.id.push(i.departmentId);
          }
        })
        .catch(function (res) {
          console.log(res);
        }),
        //Gọi api thể loại tài sản
        axios
          .get("http://localhost:59636/api/v1/Categories")
          .then(function (res) {
            for (let i of res.data) {
              //Push code thể loại tài sản vào mảng truyền combobox
              me.category.code.push(i.fixedAssetCategoryCode);
              //Push name thể loại tài sản vào mảng truyền combobox
              me.category.name.push(i.fixedAssetCategoryName);
              //Push id thể loại tài sản vào mảng truyền combobox
              me.category.id.push(i.fixedAssetCategoryId);
            }
          })
          .catch(function (res) {
            console.log(res);
          });
    } catch (res) {
      console.log(res);
    }
  },
};
</script>

<style scoped>
@import url("../../style/layout/Content.css");
</style>
