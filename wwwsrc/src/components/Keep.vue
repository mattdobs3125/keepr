<template>
<div class="keeps">

<h1>Hello and welcome to Keepr the cool kids pinterest </h1>
    <div v-if='keeps == 0 '>
        <div v-for="keep in keeps" :key="keep"></div>
    </div>
</div>
</template>



<script>
export default {
    name:"keep",
    computed:{
        keeps(){
           return this.$store.keeps;
        }
    }

}
</script>
<style>

</style>
