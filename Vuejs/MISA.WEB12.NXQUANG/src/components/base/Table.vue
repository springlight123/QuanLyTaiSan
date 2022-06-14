<template>
  <div class="father-table">
    <div class="table">
      <table class="e-table" cellspacing="0">
        <thead>
          <tr>
            <th style="width: 50px">
              <CheckBox @onCheckBox="setAllCheckBox(!isCheckAll)" />
            </th>
            <th style="min-width: 30px">{{ resources.table.stt }}</th>
            <th style="min-width: 100px">{{ resources.table.codeAssets }}</th>
            <th style="min-width: 100px">{{ resources.table.nameAssets }}</th>
            <th style="min-width: 120px">{{ resources.table.nameCategory }}</th>
            <th style="min-width: 120px">
              {{ resources.table.nameDepartment }}
            </th>
            <th style="text-align: right; width: 110px">
              {{ resources.table.quality }}
            </th>
            <th style="text-align: right; width: 110px">
              {{ resources.table.cost }}
            </th>
            <th style="text-align: right; width: 110px">
              {{ resources.table.rate }}
            </th>
            <th style="text-align: right; width: 110px">
              {{ resources.table.less }}
            </th>
            <th style="text-align: center; width: 100px">
              {{ resources.table.function }}
            </th>
          </tr>
        </thead>
        <tbody
          v-for="Pagination in countPagination"
          :key="Pagination"
          :class="pageNumber != Pagination ? 'tbodynone' : ''"
        >
          <tr
            v-for="(asset, index) in assets.slice(
              (Pagination - 1) * pageSize,
              pageSize + (Pagination - 1) * pageSize
            )"
            :key="asset.fixedAssetId"
          >
            <th>
              <CheckBox
                @onCheckBox="setCheckBox(asset)"
                :checked="isCheckAll"
              />
            </th>
            <th>{{ index + 1 + (Pagination - 1) * pageSize }}</th>
            <th>{{ asset.fixedAssetCode }}</th>
            <th>{{ asset.fixedAssetName }}</th>
            <th>{{ asset.fixedAssetCategoryName }}</th>
            <th>{{ asset.departmentName }}</th>
            <th class="right">{{ formatMoney(asset.quantity) }}</th>
            <th class="right">{{ formatMoney(asset.cost) }}</th>
            <th class="right">{{ formatMoney(asset.depreciationKH) }}</th>
            <th class="right">
              {{ formatMoney(asset.cost - asset.depreciationKH) }}
            </th>
            <th>
              <div class="table-function">
                <div
                  class="table-fix"
                  @click="moveInfor(asset.fixedAssetId, 0)"
                ></div>
                <div
                  class="table-copy"
                  @click="moveInfor(asset.fixedAssetId, 1)"
                ></div>
              </div>
            </th>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="table-footer">
      <div class="footer-infor">
        <div class="count-asset">
          Tổng số: <span>{{ countRecord }}</span> bản ghi
        </div>
        <DropDown
          class="table-footer-drop"
          :dropContents="pageSizes"
          @ondrop="onpageSize"
        />
        <Footer
          :paginationNumbers="countPagination"
          @onPagination="changePageNumber"
          :isChoose="pageNumber"
        />
      </div>
      <div style="display: flex">
        <div class="right footer-count">{{ formatMoney(countAsset) }}</div>
        <div class="right footer-count">{{ formatMoney(countCost) }}</div>
        <div class="right footer-count">
          {{ formatMoney(countDepreciationKH) }}
        </div>
        <div class="right footer-count">
          {{ formatMoney(countCost - countDepreciationKH) }}
        </div>
        <div style="text-align: center; width: 113.5px"></div>
      </div>
    </div>
    <Message ref="messageDelete" @deleteAsset="deleteAssets" />
    <Loader ref="loader" />
    <Toast :type="type" ref="toast" />
  </div>
</template>

<script>
import Resources from "../../js/Resources.js";
import CheckBox from "./CheckBox.vue";
import DropDown from "./DropDown.vue";
import axios from "axios";
import Message from "./Message.vue";
import Loader from "./Loader";
import Toast from "./Toast.vue";
import { EventBus } from "@/bus.js";
import Footer from "./Footer.vue";
export default {
  components: {
    CheckBox,
    DropDown,
    Footer,
    Message,
    Loader,
    Toast,
  },
  props: {
    isFilter: Object, //Object chứa giá trị để lọc theo phòng ban và thể loại
  },
  data() {
    return {
      assets: [], //Thông tin các tài sản
      type: "", //Loại thông báo hiện ra khi thêm, sửa,xóa thành công
      valueSearch: "", //Mã tài sản cần tìm kiếm
      isCheckAll: false, //Kiểm tra checkbox tổng
      isDisplay: true, //Tín hiệu mở form nhập liệu
      newCode: 0, //Mã tài sản lớn nhất
      assetCopyCode: "", //Mã tài sản mới nhân bản
      assetCopyId: "", //Id tài sản mới nhân bản
      assetCopy: {}, //Thông tin tài sản mới nhân bản
      countRecord: 0, //Tổng số bản ghi
      money: 0, //Tổng số tiền tài sản
      asset: {}, //Thông tin tài sản cần sửa
      pageSizes: ["20", "30", "50"], //Mảng các bản nghi 1 trang
      countPagination: 0, //Tổng số trang
      pageSize: 20, //Số bản nghi 1 trang ban đầu
      pageNumber: 1, //Trang được chọn ban đầu
      countAsset: 0, //Tổng số tài sản
      countCost: 0, //Tổng số nguyên giá
      countDepreciationKH: 0, //Tổng số hao mòn lũy kế
      resoures: {},
    };
  },
  created() {
    this.resources = Resources;
  },
  mounted() {
    //Load data
    this.getDataFilter();
    /* Nhận tín hiệu thêm, sửa để reload lại bảng
     *   CreatedBy: NXQuang(7/2/2022)
     */
    EventBus.$on("isLoad", (type) => {
      this.type = type;
      this.$refs.toast.show();
      //Load data
      this.getDataFilter();
    }),
      /* Nhận tín hiệu search để reload lại bảng
       *   CreatedBy: NXQuang(7/2/2022)
       */
      EventBus.$on("isSearch", (search) => {
        //Nhận giá trị search
        this.valueSearch = search;
        //Load data
        this.getDataFilter();
      });
  },
  methods: {
    /*  Reset các giá trị
     *   CreatedBy: NXQuang(7/2/2022)
     */
    reset() {
      this.countRecord = 0; //Reset bản nghi
      this.countCost = 0; //Reset tổng nguyên giá
      this.countRecord = 0; //Reset
      this.pageNumber = 1; //Reset
      this.countDepreciationKH = 0; //Reset
      this.assets = []; //Reset mảng chứa các tài sản
      this.countAsset = 0; //Reset tổng số tài sản
      (this.newCode = 0), //Reset mã nhân viên mới lớn nhất
        (this.isCheckAll = false); //Reset checkbox tong
    },
    /*  Tính tổng các thông tin
     *   CreatedBy: NXQuang(7/2/2022)
     */
    countAssets(asset) {
      this.countRecord += 1; //Tổng bản nghi+1 nếu tài sản qua lọc
      this.countCost += asset.cost; //Tính tổng nguyên giá
      this.countAsset += asset.quantity; //Tính tổng tài sản
      this.countDepreciationKH += asset.depreciationKH; //Tính tổng hao mòn lũy kế
      this.assets.push(asset); //Nếu tài sản thỏa mãn điều kiện lọc thì push vào mảng tài sản
    },
    /* Tính số trang
     *   CreatedBy: NXQuang(7/2/2022)
     */
    pagination(assets) {
      //Tổng số trang bằng tổng bản nghi/ số bản nghi một trang
      if (
        assets.length % this.pageSize == 0 &&
        assets.length / this.pageSize != 0
      )
        this.countPagination = Math.floor(assets.length / this.pageSize);
      //Nếu kết quả bằng 0 thì số trang+1
      else this.countPagination = Math.floor(assets.length / this.pageSize + 1);
    },
    /* Lấy dữ liệu đồng thời lọc nếu cần
     *   CreatedBy: NXQuang(7/2/2022)
     */
    async getDataFilter() {
      try {
        let me = this;
        //Biến kiểm tra tài sản có lọc qua phòng ban và vị trí không
        let check = false;
        //Hien loader
        this.$refs.loader.isDisplay = true;
        await axios
          .get("http://localhost:59636/api/v1/Assets")
          .then(function (res) {
            //Reset thông tin
            me.reset();
            //Lấy tất cả các checkbox
            for (let asset of res.data) {
              //Tìm mã lớn nhất
              if (me.newCode < asset.fixedAssetCode.slice(2))
                me.newCode = asset.fixedAssetCode.slice(2);
              //Lọc phòng ban
              if (
                me.isFilter.FilterDepar != "" &&
                asset.departmentName == me.isFilter.FilterDepar
              ) {
                //Tính hao mòn lũy kế
                if (asset.depreciationRate)
                  asset.depreciationKH = asset.depreciationRate * asset.cost;
                else asset.depreciationKH = asset.depreciationRate = 0;
                asset.isCheck = false; //Tạo thuộc tính isCheck để kiểm tra có được chọn để xóa không
                //Tính tổng các giá trị
                me.countAssets(asset);
                //Đánh dấu tài sản đã qua lọc
                check = true;
              } else if (me.isFilter.FilterDepar == "") {
                //Tính hao mòn lũy kế
                if (asset.depreciationRate != null)
                  asset.depreciationKH = asset.depreciationRate * asset.cost;
                else asset.depreciationKH = asset.depreciationRate = 0;
                //Tính tổng các giá trị
                me.countAssets(asset);
                asset.isCheck = false; //Tạo thuộc tính isCheck để kiểm tra có được chọn để xóa không
                //Đánh dấu tài sản đã qua lọc
                check = true;
              }
              //Bỏ các tài sản không phải thể loại tài sản muốn tìm
              if (
                me.isFilter.FilterCater != "" &&
                asset.fixedAssetCategoryName != me.isFilter.FilterCater &&
                check
              ) {
                me.countCost -= asset.cost; //Nếu qua lọc thể loại tài sản thì giảm tổng nguyên  giá
                me.countAsset -= asset.quantity; //Nếu qua lọc thể loại tài sản thì giảm tổng tài sản
                me.countDepreciationKH -= asset.depreciationKH; //Nếu qua lọc thể loại tài sản thì giảm tổng hao mòn lũy kế
                me.countRecord -= 1; //Nếu qua lọc thể loại tài sản thì giảm tổng bản nghi
                me.assets.pop(); //Nếu qua lọc thể loại tài sản thì bỏ tài sản khỏi mảng
              }
              //Reset biến kiểm tra tài sản có lọc qua phòng ban và thể loại tài sản không
              check = false;
            }
            //Mã tài sản lớn nhất +1
            me.newCode = "TS" + (Number(me.newCode) + 1);
            //Tính số trang
            me.pagination(me.assets);
            //Tìm kiếm theo mã tài sản
            if (me.valueSearch != "") {
              //Tính độ dài giá trị muốn tìm kiếm
              let length = me.valueSearch.length;
              //Tạo mảng chứa các tài sản mới
              let assets = me.assets;
              //Reset thông tin
              me.reset();
              for (let asset of assets) {
                //Tiến hành lọc tài sản
                if (
                  me.valueSearch.trim() ==
                    asset.fixedAssetCode.slice(0, length) ||
                  me.valueSearch.trim() == asset.fixedAssetName.slice(0, length)
                ) {
                  me.countAssets(asset); //Tính tổng các giá trị
                }
              }
              //Tính tổng số trang
              me.pagination(me.assets);
              //An loader
            }
          })
          .catch(function (res) {
            console.log(res);
          });
        //Hiện loader
        this.$refs.loader.isDisplay = false;
        //Bỏ các dấu tích cho checkbox
        me.setAllCheckBox(false);
      } catch (res) {
        console.log(res);
      }
    },
    /* Format tiền
     *   CreatedBy: NXQuang(7/2/2022)
     */
    formatMoney(value) {
      //Nếu tồn tạo thì format tiền
      if (value) {
        //Loại bỏ các số sau dâu thập phân
        value = value.toFixed();
        value = new Intl.NumberFormat("vi", {}).format(value);
        return value;
      }
      //Nếu không tồn tại value=0
      else {
        value = 0;
        return value;
      }
    },
    /* Set tất cả checkbox khi click vào checkbox tổng
     *   CreatedBy: NXQuang(7/2/2022)
     */
    setAllCheckBox(isCheckAll) {
      //Lấy tất cả các checkbox
      let checkBoxes = this.$el.querySelectorAll("input[type='checkbox']");
      //Biến dếm
      let i = 0;
      //Thay đổi giá trị checkbox tổng
      this.isCheckAll = isCheckAll;
      //Duyệt qua từng tài sản
      for (let asset of this.assets) {
        //Thay đổi đánh dấu các tài sản muốn xóa theo checkbox tổng
        this.$set(asset, "isCheck", this.isCheckAll);
        //Thay đổi dấu tích của các Checkbox  theo checkbox tổng
        checkBoxes[i].checked = asset.isCheck;
        //Biến đếm +1
        i += 1;
      }
    },
    /* Set checkbox đang chọn
     *   CreatedBy: NXQuang(7/2/2022)
     */
    setCheckBox(asset) {
      //Thay đổi đánh dấu tài sản muốn xóa
      this.$set(asset, "isCheck", !asset.isCheck);
    },

    /* Chuyển thông tin tài sản đến component FormAsset khi click nút sửa thông tin
     *   CreatedBy: NXQuang(7/2/2022)
     */
    moveInfor(assetId, type) {
      try {
        let me = this;
        //Lấy thông tin tài sản cần chuyển
        axios
          .get("http://localhost:59636/api/v1/Assets/" + assetId)
          .then(function (res) {
            //Gán data cho asset
            me.asset = res.data;
            //Nếu type=1 (copy tài sản) thì gán mã lớn nhất cho asset
            if (type == "1") me.asset.fixedAssetCode = me.newCode;
            //Truyền dữ liệu đến component FormAsset
            EventBus.$emit("assetInfor", me.asset, type);
          })
          .catch(function (res) {
            alert(res);
          });
      } catch (res) {
        console.log(res);
      }
    },
    /*  Sự kiện xóa dữ kiệu
     *   CreatedBy: NXQuang(12/2/2022)
     */
    showDelete() {
      let count = 0; //Tổng tài sản muốn xóa
      let i = 0; //Vị trí của tài sản muốn xóa thữ nhất
      let messageDelete = this.$refs.messageDelete;
      //Duyệt từng tài sản
      for (let asset of this.assets) {
        if (asset.isCheck == true) {
          count = count + 1;
        }
        //Nếu tổng tài sản muốn xóa khác 1 thì i+1
        if (count != 1) i += 1;
      }
      //Nếu tổng tài sản muốn xóa =1
      if (count == 1) {
        //Hiện Message
        messageDelete.isDisplay = true;
        //Gán type cho Message
        messageDelete.type = "delete";
        //Gán tên tài sản muốn xóa cho asset
        messageDelete.deleteName = this.assets[i].fixedAssetName;
        //Gán mã tài sản muốn xóa cho asset
        messageDelete.deleteCode = this.assets[i].fixedAssetCode;
      } else if (count > 1) {
        //Hiện Message
        messageDelete.isDisplay = true;
        //Gán type cho Message
        messageDelete.type = "deletes";
        //Nếu tổng tài sản >=10 thì gán tổng tài sản cho Message
        if (count >= 10) messageDelete.deleteCount = count;
        //Nếu tổng tài sản <10 thì thêm số 0 lên trước
        else messageDelete.deleteCount = "0" + count;
      }
    },
    /*  Sự kiện xóa dữ kiệu
     *   CreatedBy: NXQuang(12/2/2022)
     */
    async deleteAssets() {
      try {
        let me = this;
        //Biến chứa các id muốn xóa
        let assetsIdDelete = "";
        //Hiển thị confrlm có muốn xóa không
        for (let asset of this.assets) {
          //Nếu biến kiêm tra = true
          if (asset.isCheck == true) {
            //Gán id
            assetsIdDelete = assetsIdDelete + asset.fixedAssetId + ",";
          }
        }
        //Nếu chuỗi các id không rỗng
        if (assetsIdDelete != "") {
          //Bỏ dấu "," ở cuối chuỗi
          assetsIdDelete = assetsIdDelete.slice(0, assetsIdDelete.length - 1);
          // Xóa nhân viên
          await axios
            .delete(`http://localhost:59636/api/v1/Assets/${assetsIdDelete}`)
            .then(function () {
              //Gán type cho toast
              me.type = "delete";
              //Hiện toast
              me.$refs.toast.show();
              //Load data
              me.getDataFilter();
            })
            .catch(function () {
              //Hiện thông báo lỗi
              me.$refs.formActive.isDisplay = true;
              me.$refs.formActive.type = "warning-save";
              me.errors.push(this.resources.error.errorDefault);
            });
        }
      } catch (res) {
        console.log(res);
      }
    },
    /*  Sự kiện thay đổi số bản ghi một trang
     *   CreatedBy: NXQuang(12/2/2022)
     */
    onpageSize(value) {
      //Thay đổi số bản ghi
      this.pageSize = Number(value);
      //Tính số trang
      this.pagination(this.assets);
      //Reset trang được chọn là trang 1
      this.pageNumber = 1;
    },
    /*  Thay đổi trang được chọn
     *   CreatedBy: NXQuang(7/2/2022)
     */
    changePageNumber(value) {
      this.pageNumber = value;
    },
  },
  watch: {
    /*  Theo dõi sự thay đổi của phòng ban để lọc
     *   CreatedBy: NXQuang(7/2/2022)
     */
    "isFilter.FilterDepar"() {
      this.getDataFilter();
    },
    /* Theo dõi sự thay đổi của thể loại tài sản để lọc
     *   CreatedBy: NXQuang(7/2/2022)
     */
    "isFilter.FilterCater"() {
      this.getDataFilter();
    },
  },
};
</script>

<style scoped>
@import url("../../style/base/Table.css");
</style>
