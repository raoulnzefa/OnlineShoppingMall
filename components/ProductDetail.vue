<template>
<!-- 顶部快捷导航start -->
<div class="product-page">
     <div class="shortcut">
      <div class="w">
          <div style="float:left">
              <ul>
                  <li>优品汇欢迎您！&nbsp;&nbsp;</li>
                  <li>
                      <router-link :to="'/Login'">请登录</router-link>
                      <router-link :to="'/Register'" class="style-red">免费注册</router-link> 
                   </li>
              </ul>
          </div>
          <div style="float:right">
              <ul>
                  <li><a href="#">我的订单</a></li>
                  <li class="spacer"></li>
                  <li>
                      <a href="#">我的优品汇</a>
                      <i class="icmoon"></i>
                   </li>
                  <li class="spacer"></li>
                  <li><a href="#">优品汇会员</a></li>
                  <li class="spacer"></li>
                  <li>
                      <a href="#">客户服务</a>
                      <i class="icmoon"></i>
                  </li>
                  <li class="spacer"></li>
                  <li>
                      <a href="#">网站导航</a>
                      <i class="icmoon"></i>
                  </li>
                  <li class="spacer"></li>
                  <li><a href="#">手机优品汇</a></li>
              </ul>
          </div>    
      </div>
  </div>
   <!-- 顶部快捷导航end -->
   <!-- header制作 -->
   <div class="header w">
       <!-- logo优化 -->
       <div class="logo" >
           <h1><a href="index.html" title="优品汇">优品汇
              <img src="static/logo.png" alt="">
               </a>
           </h1>
       </div>
      <!-- 搜索框 -->
       <form class="product-search">
           <!--   -->

          <input type="text" id="txtSearch" placeholder="点击搜索" v-model="searchTxt"/>
          <button class="btn-search" type="submit" @click="search()">搜索</button>
      </form>
      

      <!-- 热词 -->
      <div class="hotwords">
          <a href="#" class="style-red">优惠购首发</a>
          <a href="#">亿元优惠</a>
          <a href="#">9.9团购</a>
          <a href="#">办公用品</a>
          <a href="#">零食</a>
      </div>

      <!-- 购物车 -->
      <div class="shopcart">
          <router-link :to="'/Shoppingcarts'">
          <i class="car"></i> 我的购物车<i class="arrow"></i>
          <!--这里需要把count和购物车页面的数据传输  -->
          <i class="count">{{cartcount}}</i>
          </router-link>
       </div>
     
     
   </div>
   <!-- header结束 -->

   
   <!-- nav start -->
   <div class="nav">
       <div class="w">
           <!-- 左部盒子 -->
           <div class="dropdown">
               <div class="dt">全部商品分类</div>
               
           </div>
           <!-- 右部盒子 -->
           <div class="navitems">
               <ul>
                   <li><p>服装城</p></li>
                   <li><p>美妆馆</p></li>
                   <li><p>传智超市</p></li>
                   <li><p>全球购</p></li>
                   <li><p>拍卖</p></li>
                   <li><p>团购</p></li>
                   <li><p>有趣</p></li>
               </ul>
           </div>
       </div>
   </div>

   <!-- nav end -->
     <!-- 搜索框 -->
      <div class="search-list w" v-if="issearch">
             <ul class="search-ul">
                 <li v-for="product in searchdata" :key="product.id">
                     <router-link :to="'/ProductDetail?pid='+product.id">
                     <img :src="product.productImageUrl" alt/>
                     <p class="p-price">&yen;{{product.price}}</p>
                     <p class="p-name">{{product.productName}}</p>
                     </router-link>
                 </li>
                 
             </ul>
    </div>

      <div class="product-info" v-if="notsearch">
          <div class="product-info-left">
              <img :src="product.productImageUrl" class="img" >
          </div>
          <div class="product-info-right">
              <p class="p-name">{{product.productName}}</p>
              <p class="p-price">最新价格:&yen;{{product.price}}</p>
              <p class="p-number">
                  <span class="sub" @click="subnum()">-</span>
                  <input type="text" :value="count" @change="changecount()"/>
                  <span class="add" @click="addnum()">+</span>
              </p>
              <p class="p-button">
                  <button @click="addcart()" type="submit" name="add">加入购物车</button>
              </p>
          </div>
      </div>
      
      <div class="product-detail" v-if="notsearch">
          <!-- <img src=static\pdetail.jpg class="detailimg" > -->
          <img :src="product.productDetailImageUrl" class="detailimg" >
      </div>
    </div>
</template>
<script>
import axios from 'axios';
export default {
    data(){
        return{
            count:1,
            product:{},
            notsearch:true,
            issearch:false,
             searchTxt:null,
            searchdata:[],
            cartcount:0,

        }

    },
    mounted(){
        var pid=this.$route.query.pid;
       this.getProductById(pid);
       this.getcartCount();

    },
    methods:{
         getProductById(pid){
             var thisVue=this;
            this.$http.get("http://localhost:51635/api/Products/getProductById/?id="+pid).then(function(res) {
                  thisVue.product=res.data;               
            });          
        },

        addnum(){
            this.count++;
        },
        subnum(){
            if(this.count>1)
            {
                this.count--;
            }
        },
        changecount(){
            var newCount=event.target.value;
            if(!isNaN(newCount)&&newCount>0)
            {
                this.count=newCount;
            }
            else{
                event.target.value=this.count;
            }
        },
        addcart(){
            var that=this;
            var psData=new URLSearchParams()
             psData.append("pid",this.product.id);
             psData.append("pName",this.product.productName);
             psData.append("pImg",this.product.productImageUrl);
             psData.append("count",this.count);
           axios.post("http://localhost:51635/api/Products/AddCart",psData).then(function (res) {
                if(res.data=="success"){
                  that.$router.push("/Shoppingcarts");

               }
                
            })
        },
        getProductList(fun){
            var thisVue=this;
           this.$http.get("http://localhost:51635/api/Products/GetProducts/").then(function(res){
                thisVue.searchdata=res.data;
               thisVue.searchdata.forEach(m => {
                   m["compare"]=m.saleTimes*1.5+m.clickTimes
                   
               })
               
               if(fun!=null) fun();
               console.log(thisVue.searchdata);

            })

        },
         search(){
            var that=this;
            //var searchTxt= document.querySelector("#txtSearch").value;
            that.getProductList(function(){
                if(that.searchTxt!=null&&that.searchTxt!="")
            {
                 that.searchdata=that.searchdata.filter(m=>m.productName.includes(that.searchTxt));
                //  that.$router.push("/ProductList/");
            }
            });
            that.notsearch=false;
            that.issearch=true;
         },
          getcartCount()
         {
             var thisVue=this;
            this.$http.get("http://localhost:51635/api/Products/GetShoppingcarts").then(function(res){
                var c=0;
              for(var i=Object.keys(res.data).length-1;i>=0;i--)
			{
                c+=res.data[i].count;
            }
             thisVue.cartcount =c;
                // thisVue.cartcount = Object.keys(res.data).length;
            })
         },
       
    }
};
</script>

<style >

.product-info-left{
    padding-top: 50px;
    float: left;
    width:400px;
    height: 500px;
    /* background-color: black; */
   
}

.product-info-right{
    float: right;
    padding-top: 70px;
     /* padding-left: 100px; */
     width: 718px;
     
}
.product-info-right p{
    height: 30px;
    font-weight: 700px;
    margin-bottom: 60px;
    text-align: left;
    font-size: 20px;
    
}

.p-price{
    margin-top: 80px;
    font-size: 18px;
    font-weight: bold;
    color:red;
}
.p-button button{
   margin-top: 30px;
    width: 210px;
    height: 50px;
    background-color: #c81623;
    border: none;
    border-radius: 3px;
    color: whitesmoke;
    font-size: 16px;
    font-weight: bold;
    cursor: pointer;

}
.p-number input{
    height: 34px;
    border-top: 1px solid lightgray;
    border-left: 0 none;
    border-right: 0 none;
    width: 66px;
    outline: none;
    text-align: center;
    float: left;
}

.p-number{
    width: 300px;
    height: 36px;
}

.img{
    width: 398px;
    height: 398px;
    float: left;
    border: 1px solid #ccc;
}
.p-number span{
     display: inline-block;
    width: 36px;
    height: 34px;
    border: #ccc solid 1px;
    text-align: center;
    cursor: pointer;
    line-height: 34px;
    border-radius: 3px;
    float: left;
}

.sub{
    border-radius: 3px 0 0 3px;
   
}
.add{
    border-radius:  0 3px  3px 0 ;
   
}
.product-page{
    width: 1200px;
    margin: auto;
}
.product-detail
{  margin-top: 100px;
     width: 1200px;
   
}
.detailimg{
     margin-top: 60px;
    width: 800px;
  background-color: yellowgreen;
}

.search-list
{
    height: 1000px;
     margin-top: 100px; 
    margin-bottom: 100px;
     width: 1200px;
    margin: 0 auto;

}

.search-list .search-ul li{
         width:300px;
         margin:50px 0 0 20px;
         list-style: none;
         float: left;
        border:1px solid transparent;
        padding-bottom: 10px;
     }

.search-list .search-ul li img
{
    width:300px;
    height: 200px;
}   
.search-ul li:hover{
         border-color:  lightgray;
         box-shadow: 0 0 6px rgb(228, 226, 226);
     }

.search-ul li p{
         text-align: center;
         
     }
.p-price{
        font-size: 18px;
        font-weight: bold;
        color: red;
        margin-top: 10px;
        
    }
.p-name{
        color:black;
    }

a {
text-decoration: none;
} 
.router-link-active {

    text-decoration: none;

  }

</style>