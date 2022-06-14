<template>
  <div class="outer-message" v-if="isDisplay">
    <div class="message">
      <div class="message-content">
        <div class="message-icon"></div>
        <!-- Message hủy bỏ khai báo -->
        <div class="message-type" v-if="type == 'cancel'">
          <div class="message-infor">
            Bạn có muốn hủy bỏ khai báo tài sản này?
          </div>
          <div class="message-buttons">
            <Button
              btName="Không"
              class="button-no-icon button-message-cancel"
              @onclick="isDisplay = false"
            />
            <Button
              btName="Hủy bỏ"
              class="button-no-icon button-message-ok"
              @onclick="notSave"
            />
          </div>
        </div>
        <!-- Message hủy bỏ khai báo khi sửa -->
        <div class="message-type" v-if="type == 'cancel-edit'">
          <div class="message-infor">
            Thông tin thay đổi sẽ không được cập nhật nếu bạn không lưu. Bạn có
            chắc muốn xóa tài sản này?
          </div>
          <div class="message-buttons">
            <Button
              btName="Hủy bỏ"
              class="button-no-icon button-message-cancel"
              @onclick="isDisplay = false"
            />
            <Button
              btName="Không lưu"
              class="button-no-icon button-message-not-ok"
              @onclick="notSave"
            />
            <Button
              btName="Lưu"
              class="button-no-icon button-message-ok"
              @onclick="saveData"
            />'
          </div>
        </div>
        <!-- Message xóa 1 tài sản -->
        <div class="message-type" v-if="type == 'delete'">
          <div class="message-infor">
            Bạn có muốn xóa tài sản {{ deleteCode }} - {{ deleteName }} ?
          </div>
          <div class="message-buttons">
            <Button
              btName="Không"
              class="button-no-icon button-message-cancel"
              @onclick="isDisplay = false"
            />
            <Button
              btName="Xóa"
              class="button-no-icon button-message-ok"
              @onclick="deleteAsset"
            />'
          </div>
        </div>
        <!-- Message xóa nhiều tài sản-->
        <div class="message-type" v-if="type == 'deletes'">
          <div class="message-infor">
            {{ deleteCount }} tài sản đã được chọn. Bạn có muốn xóa các tài sản
            này khỏi danh sách?
          </div>
          <div class="message-buttons">
            <Button
              btName="Không"
              class="button-no-icon button-message-cancel"
              @onclick="isDisplay = false"
            />
            <Button
              btName="Xóa"
              class="button-no-icon button-message-ok"
              @onclick="deleteAsset"
            />'
          </div>
        </div>
        <!-- Message không thể xóa tài sản-->
        <div class="message-type" v-if="type == 'cannot-delete'">
          <div class="message-infor">
            Không thể xóa tài sản này do có chứng từ phát sinh.
          </div>
          <div class="message-buttons">
            <Button
              btName="Không"
              class="button-no-icon button-message-cancel cannot-delete"
              @onclick="isDisplay = false"
            />
          </div>
        </div>
        <!-- Message không thể xóa nhiều tài sản-->
        <div class="message-type" v-if="type == 'cannot-deletes'">
          <div class="message-infor">
            04 tài sản đã được chọn không thể xóa, vui lòng kiểm tra lại tài sản
            trước khi thực hiện xóa.
          </div>
          <div class="message-buttons">
            <Button
              btName="Không"
              class="button-no-icon button-message-cancel cannot-delete"
              @onclick="isDisplay = false"
            />
          </div>
        </div>
        <div class="message-type" v-if="type == 'warning-save'">
          <div
            class="message-infor"
            style="margin-bottom: 5px"
            v-for="error of errors"
            :key="error"
          >
            {{ error }}
          </div>
          <div class="message-buttons">
            <Button
              btName="OK"
              class="button-no-icon button-message-cancel cannot-delete"
              @onclick="reset"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Button from "./Button.vue";
export default {
  components: {
    Button,
  },
  props: {
    errors: Array,
  },
  data() {
    return {
      type: "", //Loại thông báo
      isDisplay: false, //Ânr hiện thông báo
      deleteCount: 0, //Tổng số tài sản muốn xóa
      isPerform: false, //Có thực hiện thao tác muốn làm không
      deleteName: "", //Tên tài sản muốn xóa
      deleteCode: "", //Mã tài sản muốn xóa
    };
  },
  methods: {
    /*  Thực hiện xóa tài sản
     *   CreatedBy: NXQuang(9/2/2022)
     */
    deleteAsset() {
      //Thực hiện hàm  deleteAsset
      this.$emit("deleteAsset");
      //Đóng thông báo
      this.isDisplay = false;
    },
    /*  Hiện form thông báo xóa
     *   CreatedBy: NXQuang(9/2/2022)
     */
    notSave() {
      //Thực hiện hàm notSave
      this.$emit("notSave");
      //Đóng thông báo
      this.isDisplay = false;
    },
    /*  Thực hiện hàm resetErrors
     *   CreatedBy: NXQuang(9/2/2022)
     */
    reset() {
      this.isDisplay = false;
      this.$emit("resetErrors");
    },
    /*  Thực hiện hàm saveData
     *   CreatedBy: NXQuang(9/2/2022)
     */
    saveData() {
      this.isDisplay = false;
      this.$emit("saveData");
    },
  },
};
</script>

<style scoped>
@import url("../../style/base/Message.css");
</style>
