import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "//localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "//localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keep){
      state.keeps = keep
    },
    logout(state){
      state.user = {}
      router.push ('login')
    }
  },
  actions: {
    logout({commit,dismatch}){
      auth.delete('Logout')
      .then (res=>commit('logout'))
      .catch (e => console.error(e))
    },
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    getKeeps({commit ,dispatch}){
      api.get('keeps')
      .then (res=>{
        commit('setKeeps',res.data)
      })
    },
    deleteKeeps({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          dispatch('getKeeps')
        })
    }
  }
})