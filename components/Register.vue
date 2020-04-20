<template>
    <div>
        <div class="w">
            <div class="header">
                <div class="logo">
                    <a href="index.html">
                        <img src="static/logo.png" alt="">
                    </a>
                </div>
            </div>
            <!-- 注册 -->
            <div class="registterarea">
                <h3>注册新用户
                    <p>我有账号，
                        <router-link to="/Login" class="style-red"> 去登陆</router-link>
                    </p>
                </h3>
                <div class="regform">
                    <form>
                    <ul>
                        <li>
                            <!--  -->
                            <label for="username">用户名</label>
                            <input type="text" class="inp" v-model="username" placeholder="您的账户名和登录名" @blur="checkname()">
                            <span class="error">{{tiShi1}}</span>
                        </li>
            
                        <li>
                            <label for="pass">设置密码</label>
                            <input type="text" class="inp" placeholder="建议至少使用两种字符组合"  v-model="pass" @blur="checkpass()">
                            <span class="error">{{tiShi2}}</span>
                        </li>
                        <li class="safe">安全程度 
                            <em   id="ruo" v-show="degreeNumber==1">弱</em>
                            <em id="zhong" v-show="degreeNumber==2">中</em>
                            <em  id="qiang" v-show="degreeNumber==3">强</em>
                            </li>
                        <li>
                            <label for="repass">确认密码</label>
                            <input type="password" class="inp" placeholder="请再次输入密码"  v-model="repass" @blur="verify()">
                            <span class="error">{{tiShi3}}</span>
                        </li>
                        <li>
                            <label for="phone">手机号</label> 
                            <input type="text" class="inp" placeholder="请输入手机号码"  v-model="phone" @blur="checkphone()" >
                            <span class="error">{{tiShi4}}</span>
                        </li>
                        <li class="agree"> 
                            <input type="checkbox" id="box">同意协议并注册优品汇用户中心
                        </li>
                        <li>
                            <button @click.prevent="register()" type="submit" class="over">完成注册</button>
                        </li>
                    </ul>
                    </form>
                </div>
            </div>

            <!-- 版权 -->
       <div class="mod_copyright">
           <p class="mod_copyright_links">关于我们&nbsp;&nbsp;|&nbsp;&nbsp;联系我们&nbsp;&nbsp;|&nbsp;&nbsp;联系客服&nbsp;&nbsp;|&nbsp;&nbsp;合作招商&nbsp;&nbsp;|&nbsp;&nbsp;商家帮助&nbsp;&nbsp;|&nbsp;&nbsp;营销中心&nbsp;&nbsp;|&nbsp;&nbsp;友情链接&nbsp;&nbsp;|&nbsp;&nbsp;销售联盟&nbsp;&nbsp;|&nbsp;&nbsp;风险监测&nbsp;&nbsp;|&nbsp;&nbsp;隐私政策</p>
           <br> 
           <p class="mod_copyright_info">邮编：222000 电话：12345678 邮箱：1234567</p>
        </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    data(){
        return{
			tiShi1:null,
            tiShi2:null,
            tiShi3:null,
            tiShi4:null,
            degreeNumber: 0,
            username:'',
            pass:'',
            repass:'',
            phone:'',
            msgText:"",

        };
    },
    mounted(){

    },
    watch: {
    pass(newname, oldname) {
      this.msgText = this.checkStrong(newname);
      if (this.msgText > 1 || this.msgText == 1) {
          this.degreeNumber=1;
      } else {
        this.degreeNumber=1;
      }
      if (this.msgText > 2 || this.msgText == 2) {
           this.degreeNumber=2;       
      } else {
        this.degreeNumber=1;
      }
      if (this.msgText == 4) {
           this.degreeNumber=1;
      } else {
        this.degreeNumber=1;
      }

    }
  },

    methods:{
        checkname(){
            var that=this;
            that.tiShi1="";
           if(that.username==''){that.tiShi1="用户名不能为空";return false;}
          
        },
        checkStrong(sValue) {
      var modes = 0;
      //正则表达式验证符合要求的
      if (sValue.length < 1) return modes;
      if (/\d/.test(sValue)) modes++; //数字
      if (/[a-z]/.test(sValue)) modes++; //小写
      if (/[A-Z]/.test(sValue)) modes++; //大写
      if (/\W/.test(sValue)) modes++; //特殊字符

      //逻辑处理
      switch (modes) {
        case 1:
          return 1;
          break;
        case 2:
          return 2;
          break;
        case 3:
        case 4:
          return sValue.length < 4 ? 3 : 4;
          break;
      }
      return modes;
    },

    checkpass(){
        var that=this;
        that.tiShi2='';
        if(that.pass==''){
            that.tiShi2="密码不能为空";
            return false;
        }

    },

        verify(){
            this.tiShi3='';
            if(this.repass!==this.pass)
            {
                this.tiShi3="两次密码不一致,请重新输入";
                return false;

            }

        },
        checkphone(){
            if(this.phone=='')
            {
                this.tiShi4="手机号不可为空";
                return false;
            }
            else{
                this.tiShi4='';
                var re =  /^1[0-9]{10}$/;
                 let str = this.phone;
                if(!re.test(str)){
                    this.tiShi4="请输入有效的手机号码";
                    return false;
            }
           
            }
        },

        register(){
           var that=this;
           if(that.checkname()==false)
           {
               alert("请输入用户名")
           }
          else if(that.checkpass()==false)
          {
              alert("请输入密码")
          }
           else if(that.verify()==false)
          {
              alert("两次密码不一致,请重新输入")
          }
          else if(that.checkphone()==false)
          {
              alert("您未绑定手机号")
          }
          else if(box.checked==false)
          {
              alert("您未阅读协议")
          }
          else{
              var psData=new URLSearchParams()
              psData.append("uname",this.username);
              psData.append("upass",this.pass);
              psData.append("uphone",this.phone);
           axios.post("http://localhost:51635/api/Products/AddUsr",psData).then(function (res) {
                if(res.data=="success"){
                  alert("注册成功")

               }
                
            })
          }
            
        }
    }
}
</script>
<style scoped>
.header{
    height: 110px;
    border-bottom: 2px solid #b1191a;
}
.registterarea{
    height: 520px;
    border: 1px solid #ccc;
    margin-top: 20px;
}
.registterarea h3{
    height: 30px;
    border-bottom: 1px solid #ccc;
    background-color: #ececec;
    line-height: 30px;
    padding: 0 10px;
}
.registterarea p{
    float: right;   
}
.regform{
    height: 420px;
    width: 600px;
    margin:40px auto 0;
}
.regform li{
    margin-top: 10px;
}
.regform label{
    display: inline-block;
    height: 36px;
    width: 180px;
    line-height: 36px;
    text-align: right;
}
.inp{
    height: 34px;
    width: 238px;
    border: 1px solid #ccc;
    margin-left: 10px;
}
.error{
    color: #df3033;
}
.safe{
    padding-left: 250px;
    color: #b2b2b2;
}
.safe em{
    padding: 0 12px;
font-style: normal;
color:white;
}
#ruo{
    background-color:#de1111 ;

}
#zhong{
background-color: #40b83f;
}
#qiang{
    background-color: #f79100;
}
.agree{
    padding-top: 20px;
    margin-left: 180px;
}
.agree input{
    vertical-align: middle;
    margin-right: 5px;
}
.over{
    width: 200px;
    height: 34px;
    background-color: #c81623;
    border:none;
    color: white;
    font-size: 14px;
    margin:30px 200px;
}
</style>