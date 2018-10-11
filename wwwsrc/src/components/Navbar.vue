<template>
<div class="navBar row">

 <div class="col-12">
        <div class="navbar" >
            <button class="customer-account pure-button" @click="signIn">Sign In/Up</button>
              <form @submit.prevent="searchKeeps">
                <input type="text" required v-model="search">
                <button type='submit'>Search Keeps</button>
              </form>
        <div  class="navbar col-12">
            <button class="customer-account pure-button" @click="logout">LogOut</button>
            <button class="find-job pure-button" @click="userPage">Profile</button>
            <button class="logout pure-button" @click="keepForm = !keepForm">Create Keep</button>
            <form v-if="!keepForm" @submit.prevent="createKeep">
      <input type="input" v-model="keep.name" placeholder="Title">
      <input type="input" v-model="keep.description" placeholder="Keep Description">
      <input type="input" v-model="keep.img" placeholder="Img Url">
      <button type="submit">Create</button>
    </form>
        </div>
        </div>
 </div>
</div>

</template>



<script>
export default {
    name:"navbar",
    prop:["user"],
    data(){
        return{
        keepForm: true,
            keep:{
                name:"",
                description:"",
                img:"",
                userId:"",
                isPrivate:0,
                }   
                


        }
    },
computed:{
   
    user(){
        return this.$store.state.user.id
    }



},
    methods:{
        signIn(){
            this.$router.push({name:'login'})
        },
       logout(){

       },
       userPage(){
           this.$router.push({name:'profile'})
       },
       createKeep(){
           debugger
           let obj = {
            name: this.keep.name,
            description: this.keep.description,
            img: this.keep.img,
            isPrivate: this.keep.isPrivate,
            userId: this.user
           }
           this.$store.dispatch("createKeep",obj)
       },

        search(){

        }


    }

        
}
</script>
<style scoped>
.navbar{
 
        background-color: rgba(20, 183, 238, 0.829);
        padding-top: 40px;
        padding-bottom: 15px;
        border-radius: 10px;
   
}
</style>
