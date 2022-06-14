<template>
<input class="input" v-bind:value='value' v-on:input=" inputEvent" :maxlength="max" />
</template>

<script>
export default {
    props: {
        value: {
            type: String,
            default: '0'
        }, //Gía trị của compot cha truyền vào
        max: String, //Số kí tự lớn nhất được nhập
    },
    methods: {
        /* Thực hiện binding 2 chiều giữa 2 component 
         *   CreatedBy: NXQuang(13/2/2022) 
         */
        inputEvent() {
            //Lấy giá trị của input
            let value = event.target.value
            //Nếu giá trị của input=null thì value=0
            if (!value)
                value = '0'
            //Bỏ hết các kí tự không phải số
            value = value.replace(/\D+/g, "")
           
            value = (value / 100)
            //format số 
            value = String(new Intl.NumberFormat('vi', {}).format(value))
            if(value.length==3)
            value=value+'0'
            else if(value.length==1 && value!='0')
            value=value+",00"
             else if(value.length==2)
             value=value+",00"
            //Tiến hành thay đổi giá trị của trường input có phương thức '@input' 
            this.$emit('input', value)
        },
    },
}
</script>

<style scoped>
@import url("../../style/base/InputRate.css");
</style>
