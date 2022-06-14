<template>
<div class="input-number" :style="{borderColor:isFocus}">
    <input class="input" v-bind:value="value" @input="onInputNumber" @focus="isFocus='#1aa4c8'" :maxLength="max">
    <div class="input-number-icon" v-if="type!='noIcon'">
        <div class="number-icon icon-up" @click="valueUp"></div>
        <div class="number-icon icon-down" @click="valueDown"></div>
    </div>
</div>
</template>

<script>
export default {
    props: {
        value: {
            type: String,
            default: '0'
        },//biến ràng buộc với valua input
        type: {
            type: String,
            default: '0'
        },//Loại của component dùng cho từng trường hợp
        max: {
            type: String
        }//Số kí tự nhập tối đa
    },
    data() {
        return {
            isFocus: "#bbbbbb"//Biến theo dõi có focus vào component không
        }
    },
    methods: {
        /* format và binding 2 chiều khi nhập input
         *   CreatedBy: NXQuang(7/2/2022) 
         */
        onInputNumber() {
            //Lấy giá trị của input
            let value = event.target.value
            //Nếu giá trị của input=null thì value=0
            if (!value)
                value = '0'
            //Bỏ hết các kí tự không phải số
            value = value.replace(/\D+/g, "")
            //format số 
            value = String(new Intl.NumberFormat('vi', {}).format(value))
            //Tiến hành thay đổi giá trị của trường input có phương thức '@input' 
            this.$emit('input', value)
        },
        /* value+1 khi nhấn nút tăng
         *   CreatedBy: NXQuang(7/2/2022) 
         */
        valueUp() {
            //Lấy giá trị của input
            let value = this.$el.querySelector('.input').value;
            //Bỏ hết các kí tự không phải số
            value = value.replace(/\D+/g, "")
            //value+1
            value = Number(value) + 1
            //format số 
            value = String(new Intl.NumberFormat('vi', {}).format(value))
            //Tiến hành thay đổi giá trị của trường input có phương thức '@input' 
            this.$emit('input', value)
        },
        /* value-1 khi nhấn nút giảm
         *   CreatedBy: NXQuang(7/2/2022) 
         */
        valueDown() {
            //Lấy giá trị của input
            let value = this.$el.querySelector('.input').value;
            //Bỏ hết các kí tự không phải số
            value = value.replace(/\D+/g, "")
            //Nếu value lớn hơn 0 thì value-1, nếu không value = 0
            if (value > 0)
                value = Number(value) - 1
            else
                value = '0'
            //format số 
            value = String(new Intl.NumberFormat('vi', {}).format(value))
            this.$emit('input', value)
        },
        /*   Hiện border khi focus
         *   CreatedBy: NXQuang(7/2/2022) 
         */
        close(e) {
            if (!this.$el.contains(e.target)) {
                this.isFocus = '#bbbbbb'
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
}
</script>

<style scoped>
@import url("../../style/base/InputNumber.css");
</style>
