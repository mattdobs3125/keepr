<template>
  <div class="home row">
    <div class="col-12 headbar"></div>
    <div class="col-12">
<Nav user="user" keep="keeps"/>
    </div>
    
<div class="col-12">
<keep keep="keeps"/>
</div>

  </div>
</template>

<script>
import Keep from '@/components/Keep.vue'
import Nav from '@/components/Navbar.vue'
  export default {
    name: "home",
        mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }},
    components:{Keep,Nav},
    
     computed:{
        user(){
            return this.$store.state.user
        },
        keep(){
          return this.$store.state.keeps
        }
      } 
   
  }
</script>
<style scoped>
.headbar{
 
        background-color: rgba(20, 183, 238, 0.829);
        padding-top: 40px;
        padding-bottom: 15px;
        border-radius: 10px;
   
}
</style>
