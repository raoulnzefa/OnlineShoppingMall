<template>
  <body id="poster">
    <el-form class="login-container" label-position="left" label-width="0px">
      <h3 class="login_title">优品汇欢迎你</h3>
       <el-form-item>
        <el-input type="text" v-model="phone" auto-complete="off" placeholder="手机号"></el-input>
      </el-form-item>
      <el-form-item>
        <el-input type="text" v-model="username" auto-complete="off" placeholder="用户名"></el-input>
      </el-form-item>
      <el-form-item>
        <el-input type="password" v-model="password" auto-complete="off" placeholder="密码"></el-input>
      </el-form-item>
      
      <el-form-item style="width: 100%">
        <el-button type="primary" style="width: 100%;background: #505458;border: none;"  @click="login()">登录</el-button>
      </el-form-item>
    </el-form>
    <div class="alsrtInfo" :style="{display: displayStsates}" ref="alertMsg">
       <div class="profPrompt_test">{{aletMsg}}</div>
    </div>
  </body>
</template>

 

 

<script>
import axios from 'axios';
    export default {
        name: "Login",
        data() {
            return {
              phone:'',
              username: '',
              password: '',
              aletMsg: '', // 弹出框中的提示语
              displayStsates: 'none'             
            }
        },
        methods: {
            alertDia(msg) {      
                this.displayStsates = 'block'      
                this.aletMsg = msg      // 延迟2秒后消失 自己可以更改时间      
                window.setTimeout(() => {        
                    this.displayStsates = 'none'      }, 2000)    
                    },

            login() {                          
                var that=this;
                if(that.phone=='') 
                {
                    this.$message({
                    message:"手机号不能为空",
                        });
                }
                else if(that.username=='')
                {
                    this.$message({
                    message:"用户名不能为空",
                        });
                }
                else if(that.password=='')
                {
                    this.$message({
                    message:"密码不能为空",
                        }); 
                }
                else{
                    var psData=new URLSearchParams()
                    psData.append("uphone",this.phone);
                    psData.append("uname",this.username);
                    psData.append("upass",this.password);
                    
                axios.post("http://localhost:51635/api/Products/Login",psData).then(function (res) {
                        if(res.data=="success"){
                        that.alertDia("登陆成功");
                        localStorage.setItem("token", that.uphone);
                        window.location.href="index.html";
                        // that.$router.push("/");
                         
                    }
                    else {that.alertDia("登陆失败");}
                        
                    })
                    }
            }

        }

    }

</script>

 

<style>
  #poster {
    background:url("/static/com.jpg") no-repeat;
    background-position: center;
    height: 100%;
    width: 100%;
    background-size: cover;
    position: fixed;
  }

  body{
    margin: 0px;
    padding: 0;

  }

  .login-container {
    border-radius: 15px;
    background-clip: padding-box;
    margin: 180px auto;
    width: 350px;
    padding: 35px 35px 15px 35px;
    background: #fff;
    border: 1px solid #eaeaea;
    box-shadow: 0 0 25px #cac6c6;
  }

  .login_title {
    margin: 0px auto 40px auto;
    text-align: center;
    color: #505458;
  }

 

  .alsrtInfo{
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    z-index: 10;
    background: rgba(0, 0, 0, 0.1);}
    .profPrompt_test{
        border-radius: 20px;
      padding: 30px 10px;
      width: 480px;
      overflow: hidden;
      line-height: 28px;
      border: 1px solid #4eb6d3;
      color:#505458;
      position: absolute;
      background-color: #fbfbfb;
      top: 356px;
      left: 50%;
      font-size: 14px;
      font-family: Gotham-Book;
      opacity: 1;
      /* z-index: 1; */
      text-align: center;
      transform: translate(-50%, -50%);

    }

  

</style>
