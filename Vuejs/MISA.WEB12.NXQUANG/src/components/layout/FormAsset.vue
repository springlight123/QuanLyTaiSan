<template>
  <div class="outer-asset" v-show="isDisplay">
    <form class="form-asset">
      <div class="form-header">
        <div style="font-size: 2rem; font-weight: 600">
          {{ nameForm }} tài sản
        </div>
        <div class="form-close" @click="cancelMessage"></div>
      </div>
      <div class="form-input">
        <div class="form-row">
          <div class="form-field">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.codeAssets }}
              <span class="red-star">*</span>
            </div>
            <Input
              :placeholder="resources.holderInput.holderCodeAssets"
              v-model="asset.fixedAssetCode"
              fieldName="fixedAssetCode"
              max="10"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.codeAssets"
            ></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.nameAssets }}
              <span class="red-star">*</span>
            </div>
            <Input
              class="input-long"
              :placeholder="resources.holderInput.holderNameAssets"
              v-model="asset.fixedAssetName"
              fieldName="fixedAssetName"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.nameAssets"
            ></div>
          </div>
        </div>
        <div class="form-row">
          <div class="form-field">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.codeDepartment }}
              <span class="red-star">*</span>
            </div>
            <ComboBox
              :textHolder="resources.holderInput.holderCodeCategory"
              :comboContents="department"
              @onComb="changeDepar"
              :valueEdit="asset.departmentCode"
              fieldName="departmentCode"
              type="form"
              ref="comboBoxDep"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.codeDepartment"
            ></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.nameDepartment }}
              <span class="red-star">*</span>
            </div>
            <Input
              class="input-long"
              v-model="asset.departmentName"
              disabled
              fieldName="departmentName"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.nameDepartment"
            ></div>
          </div>
        </div>
        <div class="form-row">
          <div class="form-field">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.codeCategory
              }}<span class="red-star">*</span>
            </div>
            <ComboBox
              :textHolder="resources.holderInput.holderCodeDepartment"
              :comboContents="category"
              @onComb="changeCater"
              :valueEdit="asset.fixedAssetCategoryCode"
              type="form"
              fieldName="fixedAssetCategoryCode"
              ref="comboBoxCar"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.codeCategory"
            ></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.nameCategory }}
            </div>
            <Input
              class="input-long"
              v-model="asset.fixedAssetCategoryName"
              disabled
              fieldName="fixedAssetCategoryName"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.nameCategory"
            ></div>
          </div>
        </div>
        <div class="form-row">
          <div class="form-field">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.quality }} <span class="red-star">*</span>
            </div>
            <InputNumber
              class="value-number"
              v-model="asset.quantity"
              fieldName="quantity"
              fieldType="number"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.quality"
            ></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.cost }}<span class="red-star">*</span>
            </div>
            <InputNumber
              class="input-text-right"
              v-model="asset.cost"
              fieldName="cost"
              type="noIcon"
              fieldType="number"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.cost"
            ></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.rate }} <span class="red-star">*</span>
            </div>
            <InputRate
              class="input-text-right"
              v-model="asset.depreciationRate"
              fieldName="depreciationRate"
              max="5"
              fieldType="special-number"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.rate"
            ></div>
          </div>
        </div>
        <div class="form-row">
          <div class="form-field">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.dateBuy }}<span class="red-star">*</span>
            </div>
            <Input
              type="date"
              data-role="date"
              class="input-date"
              v-model="asset.purchaseDate"
              fieldName="purchaseDate"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.dateBuy"
            ></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.dateUse }} <span class="red-star">*</span>
            </div>
            <Input
              type="date"
              data-role="date"
              class="input-date"
              v-model="asset.purchaseDate"
              fieldName="purchaseDate"
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.dateUse"
            ></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.trackedYear }}
              <span class="red-star">*</span>
            </div>
            <Input
              class="input-text-right"
              v-model="asset.trackedYear"
              fieldName="trackedYear"
              disabled
            />
            <div
              class="form-warning"
              :fieldName="resources.formAssets.trackedYear"
            ></div>
          </div>
        </div>
        <div class="form-row">
          <div class="form-field">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.lifeTime }}<span class="red-star">*</span>
            </div>
            <InputNumber
              v-model="asset.lifeTime"
              fieldName="lifeTime"
              fieldType="number"
            />
            <span
              class="form-warning"
              :fieldName="resources.formAssets.lifeTime"
            >
            </span>
            <div class="warning"></div>
          </div>
          <div class="form-field form-field-right">
            <div style="margin-bottom: 8px">
              {{ resources.formAssets.rateYear }}<span class="red-star">*</span>
            </div>
            <InputNumber
              class="input-text-right"
              v-model="asset.depreciationYear"
              type="noIcon"
              fieldName="depreciationYear"
              fieldType="number"
            />
            <span
              class="form-warning"
              :fieldName="resources.formAssets.rateYear"
            ></span>
          </div>
        </div>
      </div>
      <div class="form-footer">
        <Button
          class="button-no-icon button-form-cancel"
          btName="Hủy"
          @onclick="cancelMessage"
        />
        <Button class="button-no-icon" btName="Lưu" @onclick="save" />
      </div>
    </form>
    <Message
      ref="formActive"
      @notSave="cancel"
      :errors="errors"
      @resetErrors="resetErrors"
      @saveData="save"
    />
  </div>
</template>

<script>
import Input from "../base/Input.vue";
import ComboBox from "../base/ComboBox.vue";
import Button from "../base/Button.vue";
import InputNumber from "../base/InputNumber.vue";
import axios from "axios";
import Message from "../base/Message.vue";
import InputRate from "../base/InputRate.vue";
import { EventBus } from "@/bus.js";
import Resources from "../../js/Resources.js";
export default {
  components: {
    Input,
    Button,
    ComboBox,
    InputNumber,
    Message,
    InputRate,
  },
  data() {
    return {
      resources: {},
      nameForm: "", //Tên của form
      asset: {}, //Thông tin tài sản
      isLoad: true, //Tín hiệu thực hiện reload lại table khi thêm hoặc sửa
      department: {
        name: [], //Mảng tên tài sản
        code: [], //Mảng mã tài sản
        id: [], //Mảng id tài sản
      }, //Thông tin combobox phòng ban
      category: {
        name: [], //Mảng tên tài sản
        code: [], //Mảng mã tài sản
        id: [], //Mảng id tài sản
        depreciationRate: [], //Mảng tỷ lệ hao mòn tài sản
        lifeTime: [], //Mảng số năm sử dụng tài sản
      }, //Thông tin combobox vị trí
      isDisplay: false, // Ân hiện form
      assetId: "", // Id tài sản thực hiện sửa
      errors: [], //Các thông báo lỗi truyền cho Message
      assetCopy: {}, //Biến copy biến asset dùng cho việc truyền đến API(để tránh việc validate dữ liệu ảnh hưởng đến)
      typeSave: "", //Gán phương thức lưu (thêm, sửa hay copy)
    };
  },
  methods: {
    /*  Validate dữ liệu
     *   CreatedBy: NXQuang(7/2/2022)
     */
    validateData() {
      try {
        //Lấy các children của component
        let fields = this.$children;
        //Lấy tất cả trường input
        let inputs = this.$el.querySelectorAll(".input");
        //Lấy tất cả thông báo lỗi
        let warnings = this.$el.querySelectorAll(".form-warning");
        //Biến kiểm tra validate không có lỗi
        let check = true;
        //Biến đếm
        let i = 0;
        //Gán id asset cho assetCopy
        this.assetCopy.fixedAssetId = this.asset.fixedAssetId;
        this.assetCopy.fixedAssetCategoryId = this.asset.fixedAssetCategoryId
          this.assetCopy.departmentId = this.asset.departmentId 
        //Duyệt từng input cho assetCopy
        for (let input of inputs) {
          //Lấy nội dung fielName của children fieldName
          let fieldName = fields[i].$el.getAttribute("fieldName");
          //Nếu trường trống
          if (input.value == "") {
            //Biến kiểm tra = false
            check = false;
            //Thêm border đỏ cho children
            fields[i].$el.classList.add("red-border");
            //Gán nội dung cho cảnh báo lỗi
            warnings[i].innerText =
              warnings[i].getAttribute("fieldName") +
              this.resources.error.errorNotEmpty;
            //Gán nội dung cho nội dung của Message lỗi
            this.errors.push(warnings[i].innerHTML);
            //Hiện cảnh báo lỗi
            warnings[i].classList.add("display");
          }
          //Nếu trường không trống
          else {
            //Nếu fieldName là fixedAssetCode
            if (fieldName == "fixedAssetCode") {
              //Nếu mã nhân viên != 'TS'
              if (this.asset[fieldName].slice(0, 2) != "TS") {
                //Biến kiểm tra = false
                check = false;
                //Thêm border đỏ cho children
                fields[i].$el.classList.add("red-border");
                //Gán nội dung cho cảnh báo lỗi
                warnings[i].innerText =
                  warnings[i].getAttribute("fieldName") +
                  this.resources.error.errorAssetCode;
                //Gán nội dung cho nội dung của Message lỗi
                this.errors.push(warnings[i].innerHTML);
                //Hiện cảnh báo lỗi
                warnings[i].classList.add("display");
              } else if (isNaN(this.asset[fieldName].slice(2))) {
                //Biến kiểm tra = false
                check = false;
                //Thêm border đỏ cho children
                fields[i].$el.classList.add("red-border");
                //Gán nội dung cho cảnh báo lỗi
                warnings[i].innerText = 
                  warnings[i].getAttribute("fieldName") +
                  this.resources.error.errorAssetCode;
                //Gán nội dung cho nội dung của Message lỗi
                this.errors.push(warnings[i].innerHTML);
                //Hiện cảnh báo lỗi
                warnings[i].classList.add("display");
              } else {
                //Bỏ border đỏ của children
                fields[i].$el.classList.remove("red-border");
                //Ânr cảnh báo
                warnings[i].classList.remove("display");
                //Gán property của asset cho assetCopy
                this.assetCopy[fieldName] = this.asset[fieldName];
              }
            } else if (fieldName == "purchaseDate") {
              //Lấy thời gian của tài sản
              let purchaseDate = new Date(this.asset[fieldName]).getTime();
              //Lấy thời gian hiện tại
              let today = new Date().getTime();
              //Nếu thời gian tài sản> hiện tại
              if (purchaseDate > today) {
                //Biến kiểm tra = false
                check = false;
                //Thêm border đỏ cho children
                fields[i].$el.classList.add("red-border");
                //Gán nội dung cho cảnh báo lỗi
                  warnings[i].innerText =
                  warnings[i].getAttribute("fieldName") +
                  this.resources.error.errorDayLess;
                //Gán nội dung cho nội dung của Message lỗi
                this.errors.push(warnings[i].innerHTML);
                //Hiện cảnh báo lỗi
                warnings[i].classList.add("display");
              } else {
                //Bỏ border đỏ của children
                fields[i].$el.classList.remove("red-border");
                //Ânr cảnh báo
                warnings[i].classList.remove("display");
                //Gán property của asset cho assetCopy
                this.assetCopy[fieldName] = this.asset[fieldName];
              }
            }
            //Nếu không bị lỗi validate
            else {
              //Bỏ border đỏ của children
              fields[i].$el.classList.remove("red-border");
              //Ânr cảnh báo
              warnings[i].classList.remove("display");
              //Gán các property của asset cho assetCopy
              this.assetCopy[fieldName] = this.asset[fieldName];
            }
          }
          //Biến đếm +1
          i += 1;
        }
        //Biến đếm =0
        i = 0;
        //Nếu biến kiểm tra = true thì format các số
        if (check) {
          //Duyệt từng input cho assetCopy
          for (let warning of warnings) {
            //Lấy nội dung fielName của children fieldName
            let fieldName = fields[i].$el.getAttribute("fieldName");
            //Lấy nội dung fielName của children fieldType
            let fieldType = fields[i].$el.getAttribute("fieldType");
            //Nếu fieldType =='number'
            if (fieldType == "number") {
              //Bỏ  các kí tự không phải số
              this.assetCopy[fieldName] = this.asset[fieldName].replace(
                /\D+/g,
                ""
              );
            }
            //Nếu fieldType =='special-number'
            else if (fieldType == "special-number") {
              //Thay các kí tự không phải số thành dấu,
              this.assetCopy[fieldName] =
                this.asset[fieldName].replace(/\D+/g, ".") / 100;
            }
            //Biếm đếm +1
            i += 1;
            //Remove class display
            warning.classList.remove("display");
          }
        }
        //Trả về biến kiểm tra
        return check;
      } catch (res) {
        console.log(res);
      }
    },
    /*  Reset nội dung Message lỗi
     *   CreatedBy: NXQuang(7/2/2022)
     */
    resetErrors() {
      this.errors = [];
    },
    /*   Sự kiện hiện message thông báo đóng form nhân viên
     *   CreatedBy: NXQuang(7/2/2022)
     */
    cancelMessage() {
      //Hiện Message
      this.$refs.formActive.isDisplay = true;
      //Hiện loại Message cho từng trường hợp
      if (this.asset.fixedAssetId) {
        this.$refs.formActive.type = "cancel-edit";
      } else {
        this.$refs.formActive.type = "cancel";
      }
    },
    /*   Sự kiện đóng form
     *   CreatedBy: NXQuang(7/2/2022)
     */
    cancel() {
      //Lấy các children của component
      let fields = this.$children;
      //Lấy các cảnh báo
      let warnings = this.$el.querySelectorAll(".form-warning");
      //Biến đếm
      let i = 0;
      //Duyệt từng cảnh báo
      for (let warning of warnings) {
        //Bỏ border đổ của các children
        fields[i].$el.classList.remove("red-border");
        //An thông báo
        warning.classList.remove("display");
        //Biến đếm +1
        i += 1;
      }
      //Đóng form
      this.isDisplay = false;
      //Reset asset (dữ lại 2 property là để tránh thông báo lỗi)
      this.asset = {
        depreciationRate: "0",
        cost: "0",
      };
      //Reset assetCopy  (dữ lại 2  property biến là để tránh thông báo lỗi)
      this.assetCopy = {
        depreciationRate: "0",
        cost: "0",
      };
      this.typeSave = ""; //Reset phương thức lưu
      //Đổi trạng thái của cá item combobox
      this.$refs.comboBoxCar.isChoose = -1;
      this.$refs.comboBoxDep.isChoose = -1;
    },
    /*   Sự kiến thay đổi mã loại tài sản
     *   CreatedBy: NXQuang(7/2/2022)
     */
    changeCater(comboContent) {
      //Đổi mã loại tài sản
      this.asset.fixedAssetCategoryCode = comboContent;
      //Biến đếm
      let i = 0;
      //Duyệt từng mã
      for (let caterCode of this.category.code) {
        //Nếu mã đang duyệt = mã đã chọn
        if (caterCode == comboContent) {
          //Đổi id loại tài sản
          this.asset.fixedAssetCategoryId = this.category.id[i];
          //Đổi tên loại tài sản
          this.$set(
            this.asset,
            "fixedAssetCategoryName",
            this.category.name[i]
          );
          //Đổi % hao mòn
          this.$set(
            this.asset,
            "depreciationRate",
            this.category.depreciationRate[i]
              ? String(
                  new Intl.NumberFormat("vi", {}).format(
                    this.category.depreciationRate[i] * 100
                  )
                )
              : "0"
          );
          //Đổi thời gian sử dụng
          this.$set(
            this.asset,
            "lifeTime",
            this.category.lifeTime[i] ? String(this.category.lifeTime[i]) : "0"
          );
          break;
        }
        i += 1;
      }
    },
    /*   Sự kiến thay đổi mã phòng ban
     *   CreatedBy: NXQuang(7/2/2022)
     */
    changeDepar(comboContent) {
      //Đổi mã phòng ban
      this.asset.departmentCode = comboContent;
      //Biến đếm
      let i = 0;
      //Duyệt từng mã phòng ban
      for (let departmentCode of this.department.code) {
        //Nếu mã phòng ban == mã vừa chọn
        if (departmentCode == comboContent) {
          //Đổi id phòng ban
          this.asset.departmentId = this.department.id[i];
          //Đổi tên phòng ban
          this.$set(this.asset, "departmentName", this.department.name[i]);
          //Thoát vòng lặp
          break;
        }
        //Biến đếm+1
        i += 1;
      }
    },
    /*   Sự kiến lưu dữ liệu
     *   CreatedBy: NXQuang(7/2/2022)
     */
    save() {
      try {
        let me = this;
        // Nếu có id và type = 0 thì tiến hành sửa thông tin tài sản
        if (this.validateData()) {
          this.assetCopy.depreciationYear="0"
          if (this.asset.fixedAssetId && this.typeSave == "0") {
            axios
              .put(
                `http://localhost:59636/api/v1/Assets/${me.assetCopy.fixedAssetId}`,
                me.assetCopy
              )
              .then(function () {
                //Đóng form nhập liệu
                me.cancel();
                //Truyền biến isload đến component table để làm tín hiệu reload lại table
                EventBus.$emit("isLoad", "save");
              })
              //Báo lỗi
              .catch(function (res) {
                switch (res.response.status) {
                  case 400:
                    {
                      //Hiện thông báo lỗi
                      me.$refs.formActive.isDisplay = true;
                      me.$refs.formActive.type = "warning-save";
                      me.errors.push(res.response.data.userMSG);
                    }
                    break;
                  default: {
                    //Hiện thông báo lỗi
                    me.$refs.formActive.isDisplay = true;
                    me.$refs.formActive.type = "warning-save";
                    me.errors.push(this.resources.error.errorDefault);
                  }
                }
              });
            // Nếu không có id và type = 1 thì tiến hành thêm mới tài sản
          } else if (!this.asset.fixedAssetId || this.typeSave == "1") {
            if(this.typeSave == "1")
            this.assetCopy.fixedAssetId=undefined
            axios
              .post("http://localhost:59636/api/v1/Assets", me.assetCopy)
              .then(function () {
                //Đóng form nhập liệu
                me.cancel();
                //Truyền biến isload đến component table để làm tín hiệu reload lại table
                EventBus.$emit("isLoad", "save");
              })
              //Báo lỗi
              .catch(function (res) {
                switch (res.response.status) {
                  case 400:
                    {
                      //Hiện thông báo lỗi
                      me.$refs.formActive.isDisplay = true;
                      me.$refs.formActive.type = "warning-save";
                      me.errors.push(res.response.data.userMSG);
                    }
                    break;
                  default: {
                    //Hiện thông báo lỗi
                    me.$refs.formActive.isDisplay = true;
                    me.$refs.formActive.type = "warning-save";
                    me.errors.push( this.resources.error.errorDefault);
                  }
                }
              });
          }
        } else {
          this.$refs.formActive.isDisplay = true;
          this.$refs.formActive.type = "warning-save";
        }
      } catch (res) {
        console.log(res);
      }
    },
  },
  created() {
    this.resources = Resources;
    /*   Nhận thông tin tài sản khi sửa, copy
     *   CreatedBy: NXQuang(7/2/2022)
     */
    EventBus.$on("assetInfor", (asset, typeSave) => {
      try {
        //Gán phương thức lưu ( sửa hay copy)
        this.typeSave = typeSave;
        //Gán tên cho form
        if (typeSave == "1") this.nameForm = "Thêm";
        else this.nameForm = "Sửa";
        // Gán tài sản vừa chuyển cho asset
        this.asset = asset;
        //Thay đổi %hao mòn cho phù hợp với  trương input
        if (me.asset.depreciationRate) {
          me.asset.depreciationRate = Number(
            me.asset.depreciationRate * 100
          ).toFixed(2);
          me.asset.depreciationRate = String(
            me.asset.depreciationRate.replace(/[^0-9]/g, ",")
          );
        } else me.asset.depreciationRate = "0";
        //Thay đổi nguyên giá cho phù hợp với  trương input
        if (me.asset.cost) {
          me.asset.cost = Number(me.asset.cost).toFixed();
          me.asset.cost = new Intl.NumberFormat("vi", {}).format(me.asset.cost);
        } else me.asset.cost = "0";
        //Thay đổi năm theo dõi cho phù hợp với  trương input
        if (me.asset.trackedYear)
          me.asset.trackedYear = String(me.asset.trackedYear);
        else me.asset.trackedYear = "0";
        //Thay đổi số lượng cho phù hợp với  trương input
        if (me.asset.quantity)
          me.asset.quantity = new Intl.NumberFormat("vi", {}).format(
            me.asset.quantity
          );
        else me.asset.quantity = "0";
        //Thay đổi số năm sử dụng cho phù hợp với  trương input
        if (me.asset.lifeTime)
          me.asset.lifeTime = new Intl.NumberFormat("vi", {}).format(
            me.asset.lifeTime
          );
        else me.asset.lifeTime = "0";
        //Thay đổi ngày mua, ngày bắt đầu sử dụng cho phù hợp với  trương input
        if (me.asset.purchaseDate) {
          //Lấy date
          let thisDate = new Date(me.asset.purchaseDate);
          //Lấy ngày
          let date = thisDate.getDate();
          date = date < 10 ? `0${date}` : date;
          //Lấy tháng
          let month = thisDate.getMonth() + 1;
          month = month < 10 ? `0${month}` : month;
          //Lấy năm
          let year = thisDate.getFullYear();
          //Tạo ngày tháng năm
          let value = `${year}-${month}-${date}`;
          //Gán ngày tháng năm cho ngày mua, ngày bắt đầu sử dụng
          me.$set(me.asset, "purchaseDate", value);
        }
        if (this.asset.depreciationRate == "0" && this.asset.cost == "0")
          this.asset.depreciationYear = "0";
        //Hiện form
        this.isDisplay = true;
      } catch (res) {
        console.log(res);
      }
    });
    /*   Hiện form khi thêm mới
     *   CreatedBy: NXQuang(7/2/2022)
     */
    EventBus.$on("assetDisplay", (newCode) => {
      try {
        //Gán tên cho form
        this.nameForm = "Thêm";
        // Nhận thông tin tài sản muốn sửa từ component table
        this.isDisplay = true;
        // Nhận mã tài sản lớn nhất +1
        this.asset.fixedAssetCode = newCode;
        //Lấy date
        let thisDate = new Date();
        //Lấy ngày
        let date = thisDate.getDate();
        date = date < 10 ? `0${date}` : date;
        //Lấy tháng
        let month = thisDate.getMonth() + 1;
        month = month < 10 ? `0${month}` : month;
        //Lấy năm
        let year = thisDate.getFullYear();
        //Tạo ngày, tháng, năm
        let value = `${year}-${month}-${date}`;
        //Gán thông tin ngày mua, ngày bắt đầu sử dụng
        this.$set(this.asset, "purchaseDate", value);
        //Gán thông tin năm theo dõi
        this.$set(this.asset, "trackedYear", String(year));
        //Gán thông tin nguyên giá
        this.$set(this.asset, "cost", "0");
        //Gán thông tin % hao mòn
        this.$set(this.asset, "depreciationRate", "0");
        //Gán thông tin số lượng
        this.$set(this.asset, "quantity", "0");
        //Gán thông tin % hao mòn
        this.$set(this.asset, "depreciationYear", "0");
        this.$set(this.asset, "fixedAssetName", "");
      } catch (res) {
        console.logres;
      }
    });
    try {
      var me = this;
      /*  Lấy dữ liệu phòng ban
       *   CreatedBy: NXQuang(7/2/2022)
       */
      axios
        .get("http://localhost:59636/api/v1/Departments")
        .then(function (res) {
          for (let i of res.data) {
            //push mã vào hàm
            me.department.code.push(i.departmentCode);
            //push tên vào hàm
            me.department.name.push(i.departmentName);
            //push id vào hàm
            me.department.id.push(i.departmentId);
          }
        })
        .catch(function (res) {
          console.log(res);
        }),
        /*  Lấy dữ liệu loại tài sản
         *   CreatedBy: NXQuang(7/2/2022)
         */
        axios
          .get("http://localhost:59636/api/v1/Categories")
          .then(function (res) {
            for (let i of res.data) {
              //push mã vào hàm
              me.category.code.push(i.fixedAssetCategoryCode);
              //push tên vào hàm
              me.category.name.push(i.fixedAssetCategoryName);
              //push id vào hàm
              me.category.id.push(i.fixedAssetCategoryId);
              //push % hao mòn vào hàm
              me.category.depreciationRate.push(i.depreciationRate);
              //push năm sử dụng vào hàm
              me.category.lifeTime.push(i.lifeTime);
            }
          })
          .catch(function (res) {
            console.log(res);
          });
    } catch (res) {
      console.log(res);
    }
  },
  watch: {
    /*  Theo dõi %hao mòn
     *   CreatedBy: NXQuang(7/2/2022)
     */
    "asset.depreciationRate"(value) {
      //Nếu % hao mòn rỗng thì gán =0
      if (!value) this.$set(this.asset, "depreciationRate", "0");
      //Tính kết quả hao mòn năm
      let result =
        value.replace(/[^0-9]/g, ".") * this.asset.cost.replace(/[^0-9]/g, "");
      result = (result / 100).toFixed();
      //Gán kết quả hao mòn năm
      this.asset.depreciationYear = new Intl.NumberFormat("vi", {}).format(
        result
      );
    },
    /*  Theo dõi nguyên giá
     *   CreatedBy: NXQuang(7/2/2022)
     */
    "asset.cost"(value) {
      //Nếu nguyên giá rỗng thì gán= 0
      if (!value) this.$set(this.asset, "cost", "0");
      //Tính kết quả hao mòn năm
      let result =
        value.replace(/[^0-9]/g, "") *
        this.asset.depreciationRate.replace(/[^0-9]/g, ".");
      result = (result / 100).toFixed();
      //Gán kết quả hao mòn năm
      this.asset.depreciationYear = new Intl.NumberFormat("vi", {}).format(
        result
      );
    },
  },
};
</script>

<style scoped>
@import url("../../style/layout/FormAsset.css");
</style>
