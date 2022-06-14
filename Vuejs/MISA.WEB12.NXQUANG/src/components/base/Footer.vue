<template>
  <div class="footer">
    <div class="footer-pagination">
      <div
        class="footer-pagination-icon footer-pagination-icon-left"
        @click="downPagination"
      ></div>
      <div
        class="footer-pagination-number"
        @click="changePagination(1)"
        :class="[1 == paginationChoose ? 'choose' : '']"
      >
        {{ 1 }}
      </div>
      <div
        class="footer-pagination-number"
        v-show="paginationChoose > 3 && paginationNumbers > 4"
      >
        {{ "..." }}
      </div>
      <div
        class="footer-pagination-number"
        v-for="paginationNumber in paginationNumbers"
        :key="paginationNumber"
        @click="changePagination(paginationNumber)"
        :class="[paginationNumber == paginationChoose ? 'choose' : '']"
        v-show="showPagination(paginationNumber, paginationNumbers)"
      >
        {{ paginationNumber }}
      </div>
      <div
        class="footer-pagination-number"
        v-show="
          paginationChoose < paginationNumbers - 2 && paginationNumbers > 4
        "
      >
        {{ "..." }}
      </div>
      <div
        class="footer-pagination-number"
        @click="changePagination(paginationNumbers)"
        :class="[paginationNumbers == paginationChoose ? 'choose' : '']"
        v-show="paginationNumbers != 1"
      >
        {{ paginationNumbers }}
      </div>
      <div
        class="footer-pagination-icon footer-pagination-icon-right"
        @click="upPagination"
      ></div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    paginationNumbers: Number, //Số trang
    isChoose: Number || 1, //Kiểm tra trang đang được chọn(giá trị mặc định là 1)
  },
  data() {
    return {
      paginationChoose: 1, //Trang đang được chọn
    };
  },
  methods: {
    /*  Thay đổi trang được chọn
     *   CreatedBy: NXQuang(9/2/2022)
     */
    changePagination(value) {
      //Thay đổi trang đang được chọn
      this.paginationChoose = value;
      //Thực hiện hàm onPagination, truyền số của trang đang được chọn
      this.$emit("onPagination", this.paginationChoose);
    },
    /*  Xuống 1 trang
     *   CreatedBy: NXQuang(9/2/2022)
     */
    downPagination() {
      //Nếu trang được chọn lớn hơn 1 thì xuống 1 trang
      if (this.paginationChoose > 1) {
        this.paginationChoose = this.paginationChoose - 1;
        //Thực hiện hàm onPagination, truyền số của trang đang được chọn
        this.$emit("onPagination", this.paginationChoose);
      }
    },
    /*  Lên 1 trang
     *   CreatedBy: NXQuang(9/2/2022)
     */
    upPagination() {
      //Nếu trang được chọn bé hơn trang lớn nhất thì lến 1 trang
      if (this.paginationChoose < this.paginationNumbers) {
        this.paginationChoose = this.paginationChoose + 1;
        //Thực hiện hàm onPagination, truyền số của trang đang được chọn
        this.$emit("onPagination", this.paginationChoose);
      }
    },
    /*  Hiện các số trang
     *   CreatedBy: NXQuang(9/2/2022)
     */
    showPagination(paginationNumber, paginationNumbers) {
      //Nếu số trang khác đang xét khác 1 và không bằng số trang lớn nhất
      if (paginationNumber != 1 && paginationNumber != paginationNumbers) {
        //Nếu số trang khác đang xét nhỏ hơn 4 thì hiện ra
        if (paginationNumbers <= 4) return true;
        //Nếu số trang khác đang xét lớn hơn 4 thì hiện ra
        else {
          //Nếu số trang đang bé hơn 3
          if (this.paginationChoose < 3) {
            //Nếu số trang đang xét <= 3 thì hiện ra
            if (paginationNumber <= 3) return true;
            //Nếu số trang đang xét > 3 thì ẩn đi
            else return false;
          }
          //Nếu số trang lớn nhất = số trang đang chọn
          else if (paginationNumbers == this.paginationChoose) {
            //Nếu số trang đang xét >= số trang lớn nhất-2 thì hiện
            if (paginationNumber >= paginationNumbers - 2) return true;
            else return false;
          }
          //Nếu số trang lớn nhất không bằng số trang đang chọn
          //Nếu số trang đang xét lớn hơn hoặc bé hơn số trang đang chọn 1 số
          else if (
            paginationNumber >= this.paginationChoose - 1 &&
            paginationNumber <= this.paginationChoose + 1
          )
            return true;
          else return false;
        }
      } else return false;
    },
  },
  watch: {
    /* Nếu trang được chọn thay đổi từ component cha thì component con thay đổi theo
     *   CreatedBy: NXQuang(9/2/2022)
     */
    isChoose() {
      this.paginationChoose = this.isChoose;
    },
  },
};
</script>

<style scoped>
@import url("../../style/base/Footer.css");
</style>
