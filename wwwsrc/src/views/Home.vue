<template>
  <div class="home">
    <h1>Welcome Home</h1>
<keep/>
  </div>
</template>

<script>
import Keep from '@/components/Keep.vue'
  export default {
    name: "home",
    components:{Keep}
    // mounted() {
    //   //blocks users not logged in
    //   if (!this.$store.state.user.id) {
    //     this.$router.push({ name: "login" });
    //   }
    
  };
</script>