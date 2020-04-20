<template>
  <div>
      <!-- 顶部快捷导航start -->
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
               <div class="dd" v-if="notsearch">
                   <ul>
                      
                       <li class="menu_item" ><router-link :to="'ProductList'"><em>家用电器</em></router-link><i></i></li>
                       
                       <li class="menu_item"><em>手机</em>、<em>数码</em>、<em>通信</em><i></i></li>
                       <li class="menu_item"><em>办公</em><i></i></li>
                       <li class="menu_item"><em>电脑</em><i></i></li>
                       <li class="menu_item"><em>家居</em><i></i></li>
                       <li class="menu_item"><em>母婴</em><i></i></li>
                       <li class="menu_item"><em>图书</em><i></i></li>
                       <li class="menu_item"><em>男装</em>、<em>女装</em>、<em>童装</em><i></i></li>
                       <li class="menu_item"><em>家用电器</em><i></i></li>
                       <li class="menu_item"><em>家用电器</em><i></i></li>

                   </ul>
               </div>
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
 

    <div class="w" v-if="notsearch">
           <div class="main">
               <!-- 焦点图 -->
               <div class="foucus">
               <!-- 左按钮 -->
                  <a href="#" class="arrow-l">&lt;</a>
                <!-- 右按钮 -->
                  <a href="#" class="arrow-r" >&gt;</a>
                  <img src="static/focus.jpg.webp" class="slide"> 
                
                 <!--圆点  -->
                 <!-- 未实现动态效果 -->
                <ul class="circle">
                    <!-- :class="{'current-li':liIndex==1}" -->
                    <li  @click="changeli1()"></li>
                    <li ></li>
                    <li></li>
                    <li></li>
                    <li ></li>
                </ul> 
        
               </div>
               <div class="newsflash">
                   <div class="news">
                       <div class="news_hd">优品汇快报<a href="#">更多</a></div>
                       <div class="news_bd">
                           <ul>
                               <li><a href="#">【特惠】骁龙865对比麒麟990 5G！</a></li>
                               <li><a href="#">【特惠】512GB+骁龙855P放松至千元</a></li>
                               <li><a href="#">【特惠】N95口罩并非所有人都能戴</a></li>
                               <li><a href="#">【特惠】笔记本怎么选</a></li>
                               <li><a href="#">【特惠】爆款耳机五折秒</a></li>
                           </ul>
                       </div>
                   </div>
                   <div class="lifeservice">
                       <li><a href="#"><i class="service_ico"><img src="static/huafei.png" alt=""></i><p>话费</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/jipiao.png" alt=""></i><p>机票</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/dianyingpiao.png" alt=""></i><p>电影票</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/caipiao.png" alt=""></i><p>彩票</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/jiudian.png" alt=""></i><p>酒店</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/youxi.png" alt=""></i><p>游戏</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/huochepiao.png" alt=""></i><p>车票</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/zhongchou.png" alt=""></i><p>众筹</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/licai.png" alt=""></i><p>理财</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/lipinka.png" alt=""></i><p>礼品卡</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/jiayouka.png" alt=""></i><p>加油卡</p></a></li>
                       <li><a href="#"><i class="service_ico"><img src="static/baitiao.png" alt=""></i><p>白条</p></a></li>>
                     

                   </div>
                   <img src="static/bargin.jpg.webp" alt="" class="bargin">
                   
               </div>
           </div>          
       </div>

       
        <!-- 推荐 -->
        <div class="recommend" v-if="notsearch">
            <div class="recommend_hd"><img src="static/clock.png" alt=""><h3>今日推荐</h3></div>
            <div class="recommend_bd">
                <ul>
                    <li>
                        <a href="#"><img src="static/rec1.jpg" alt=""></a>
                    </li>
                    <li> <a href="#"><img src="static/rec2.jpg.webp" alt=""></a></li>
                    <li> <a href="#"><img src="static/rec3.jpg.webp" alt=""></a></li>
                    <li> <a href="#"><img src="static/rec4.jpg.webp" alt=""></a></li>
                </ul>
            </div>
        </div> 

        <!-- 楼层 -->
        <div class="floor" v-if="notsearch">
            <div class="jiadian">
                <div class="box_hd">
                  <h3>家用电器</h3>
                  <div class="tab_list">
                      <ul>
                          <li><a href="#" class="style-red">热门</a>|</li>
                          <li><a href="#">大家电</a>|</li>
                      </ul>
                  </div>
                </div>
                <div class="box_bd">
                    <ul  class="tab_con">                      
                        <li  class="w220" v-for="(product,index) in productlist.slice(0,5) " :key="product.id" >
                             <router-link :to="'/ProductDetail?pid='+product.id">                    
                            <img class="hotimg" :src="product.productImageUrl" alt="">
                             <div class="tab_con_item">{{product.productName}}</div>
                             <div class="tab_price">&yen;{{product.price}}</div>
                              </router-link>
                        </li>
                    </ul>
                    <!-- 用来做热门和下面的互选 -->
                   <ul></ul>
                </div>
            </div>

            
        </div>


        <!-- 侧边栏 -->
        <div class="fixedtool">
            <ul>
                <li class="current">家用电器</li>
                <li>家用电器</li>
            </ul>
        </div>

    <!-- 底部 -->
   <div class="footer">
     <div class="w">
       <div class="mod_service">
         <ul>
           <li><i class="mod_service_icon mod_service_zheng"></i>
            <div class="mod_service_tit">
                <h5>正品保障</h5>
                <p>正品保障、提供发票</p>
            </div>
           </li>
           <li><i class="mod_service_icon mod_service_kuai"></i>
            <div class="mod_service_tit">
                <h5>极速物流</h5>
                <p>极速物流、极速送达</p>
            </div></li>
           <li><i class="mod_service_icon mod_service_bao"></i>
            <div class="mod_service_tit">
                <h5>无忧售后</h5>
                <p>7天无理由退换货</p>
            </div></li>
           <li><i class="mod_service_icon mod_service_te"></i>
            <div class="mod_service_tit">
                <h5>特色服务</h5>
                <p>私人定制服务套餐</p>
            </div></li>
           <li><i class="mod_service_icon mod_service_bang"></i>
            <div class="mod_service_tit">
                <h5>帮助中心</h5>
                <p>您的贴心指南</p>
            </div></li>
         </ul>
       </div>
       <!-- 帮助 -->
       <div class="mod_help">
           <dl class="mod_help_item">
               <dt>购物指南</dt>
               <dd><a href="#">购物流程</a></dd>
               <dd><a href="#">会员介绍</a></dd>
               <dd><a href="#">生活旅行/团购</a></dd>
               <dd><a href="#">常见问题</a></dd>
               <dd><a href="#">大家电</a></dd>
               <dd><a href="#">联系客服</a></dd>
           </dl>
           <dl class="mod_help_item">
            <dt>配送方式</dt>
            <dd><a href="#">上门自提</a></dd>
            <dd><a href="#">21h限时达</a></dd>
            <dd><a href="#">配送服务查询</a></dd>
            <dd><a href="#">配送费收取标准</a></dd>
            <dd><a href="#">海外配送</a></dd>
        </dl>
        <dl class="mod_help_item">
            <dt>支付方式</dt>
            <dd><a href="#">货到付款</a></dd>
            <dd><a href="#">在线支付</a></dd>
            <dd><a href="#">分期付款</a></dd>
            <dd><a href="#">公司转账</a></dd>
        </dl>
        <dl class="mod_help_item">
            <dt>售后服务</dt>
            <dd><a href="#">售后政策</a></dd>
            <dd><a href="#">价格保护</a></dd>
            <dd><a href="#">退款说明</a></dd>
            <dd><a href="#">返修、退换</a></dd>
            <dd><a href="#">取消订单</a></dd>
        </dl>
        <dl class="mod_help_item">
            <dt>特色服务</dt>
            <dd><a href="#">夺宝岛</a></dd>
            <dd><a href="#">DIY装机</a></dd>
            <dd><a href="#">延保服务</a></dd>
            <dd><a href="#">优品汇卡</a></dd>
            <dd><a href="#">优品汇通信</a></dd>
        </dl>
        <dl class="mod_help_item">
            <dt>帮助中心</dt>
            <dd><img src="static/erweima.png" alt="">
            <p>优品汇客户端</p></dd>
        </dl>
       </div>

       <!-- 版权 -->
      <div class="mod_copyright">
           <p class="mod_copyright_links">关于我们&nbsp;&nbsp;|&nbsp;&nbsp;联系我们&nbsp;&nbsp;|&nbsp;&nbsp;联系客服&nbsp;&nbsp;|&nbsp;&nbsp;合作招商&nbsp;&nbsp;|&nbsp;&nbsp;商家帮助&nbsp;&nbsp;|&nbsp;&nbsp;营销中心&nbsp;&nbsp;|&nbsp;&nbsp;友情链接&nbsp;&nbsp;|&nbsp;&nbsp;销售联盟&nbsp;&nbsp;|&nbsp;&nbsp;风险监测&nbsp;&nbsp;|&nbsp;&nbsp;隐私政策</p>
           <br> 
           <p class="mod_copyright_info">邮编：222000 电话：12345678 邮箱：1234567</p>
        </div>

     </div>
   </div>
        

       

  </div>
  
</template>
<script>
export default {
    data(){
        return{
            productlist:[],
            searchTxt:null,
            searchdata:[],
            cartcount:0,
            notsearch:true,
            issearch:false,
        }
    },
    mounted(){
         this.getHotProductList();
         this.getcartCount();
    },
    methods:{
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
        getHotProductList(fun){
            var thisVue=this;
            this.$http.get("http://localhost:51635/api/Products/GetPhoneProducts/").then(function(res){
                thisVue.productlist=res.data;
               thisVue.productlist.forEach(m => {
                   m["compare"]=m.saleTimes*1.5+m.clickTimes
                   
               })
               
               if(fun!=null) fun();
               console.log(thisVue.productlist);

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
}
</script>
<style scoped>

.main{
    margin-left: 219px;
    margin-top: 10px;
    height: 455px;
    width:980px;
}
.foucus{
    position: relative;
    float: left;
    width: 720px;
    height: 455px;
    background-color: blue;
}
.foucus img{
     width: 720px;
    height: 455px;

}
.arrow-l{
    position: absolute;
    top:50%;
    margin-top: -15px;
    left: 0;
    width: 20px;
    height: 30px;
   background-color: rgba(0,0, 0, .2);
   text-decoration: none;
   color: #fff;
   text-align: left;
   line-height: 30px;
   border-top-right-radius:15px;
   border-bottom-right-radius:15px ;   
}
.arrow-l:hover{
    background-color: rgba(0,0, 0, .4);
}
.arrow-r:hover{
    background-color: rgba(0,0, 0, .4);
}
.arrow-r{
    position: absolute;
    top:50%;
    margin-top: -15px;
    right: 0;
    width: 20px;
    height: 30px;
   background-color: rgba(0,0, 0, .2);
   text-decoration: none;
   color: #fff;
   text-align: right;
   line-height: 30px;
   border-top-left-radius:15px;
   border-bottom-left-radius:15px ;   
}

.circle{
    position:absolute;
    left: 50%;
    margin-left: -60px;
    bottom: 15px;
    width: 120px;
    height: 20px;
    
    background:rgba(255,255,255,0.3);
    border-radius: 10px;
}
.circle li{
    float: left;
    width: 12px;
   height: 12px;   
    background-color: #fff;
    border-radius: 50%;
    margin: 6px;
    cursor: pointer;
}
.circle .current-li{
    background-color:red;
}

.newsflash{
    float: right;
    height: 455px;
    width: 250px;
}

.news{
    height: 163px;
    border:1px solid #ccc;
    
}

.news_hd{
    height: 32px;
    border-bottom: 1px dotted #ccc;
    padding:0 15px;
    font-size: 14px;
    line-height: 32px;

}
.news_hd a{
    float: right;
    font-family: 'icomoon';
    font-size: 12px;
}
.news_bd li{
    height: 23px;
}
.news_bd{
    padding: 10px 0 0 15px;
}
.lifeservice{
    height: 208px;
    border: 1px solid #ccc;
    border-top:0;
    overflow: hidden;
}
.lifeservice ul{
    width: 252px;
}
.lifeservice li{
    float: left;
    width: 62px;
    height: 70px;
    border-right:1px solid #ccc ;
    border-bottom: 1px solid #ccc;
}
.lifeservice li a{
    display: block;
    overflow: hidden;
}
.lifeservice li p{
    text-align: center;
}
.service_ico{
    display: block;
    width: 24px;
    height: 24px;
    margin: 10px auto;
}
.bargin{
    height: 80px;
    margin-top: 4px;
    width: 250px;

}

.recommend{
    height: 163px;
    margin: 10px;
     width: 1200px;
    margin: 10px auto;
} 

.recommend_hd{
    float: left;
    width: 210px;
    height: 164px;
    background-color: #5c5251;
    text-align: center;
}
.recommend_hd img{
    margin: 20px 0 5px 0;
}
.recommend_hd h3{
    font-size: 18px;
    color: #fff;
    font-weight: normal;
}
.recommend_bd{
    float: left;
    height: 164px;
    width: 990px;
    background-color:lightgray;
}
.recommend_bd li{
    float: left;
    height: 145px;
    width: 245px;
    border-right: 1px solid #ccc;
    margin-top: 10px;
    background-color:purple;
}
.recommend_bd li img{
    float: left;
    height: 145px;
    width: 249px;
}
/* 楼层 */
.jiadian
{
    width: 1200px;
    margin: 20px auto;
}
.box_hd{
    height: 30px;
    border-bottom: 2px solid #c81623;
}
.box_hd h3{
    font-size: 18px;
    float: left;
    color: #c81623;
}
.tab_list{
    float: right;
    line-height: 30px;
}
.tab_list li{
    float: left;
}
.tab_list li a{
    margin: 0 15px;
}

.box_bd{
    height: 361px;
    border: 1px solid #ccc;
}

.w220{
     width: 230px;
     margin: 0 2px;
    

}
.hotimg
{
    height:240px;
    width: 210px;
    margin: 10px auto;
    
}
.tab_con li{
    height: 361px;
    float: left;
}
.tab_con_item{
    
    text-align: center;
}
.tab_price{
    margin-top: 2px;
    color: #c81623;
    text-align: center;
    font-size: 18px;
}
.tab_con_list{
    overflow: hidden;
    margin-bottom:15px ;
}
.tab_con_list li{
    float: left;
    width: 80px;
    height: 32px;
    line-height: 32px;
    border-bottom: 1px solid #ccc;
    margin-left: 10px;
    text-align: center;
}

/* 侧边栏 */
.fixedtool{
    position: fixed;
    top: 100px;
    left:50%;
    margin-left: -676px;
    width: 66px;

}

.fixedtool li{
    height: 32px;
    line-height: 32px;
    text-align: center;
    font-size: 12px;
    border-bottom: 1px solid #ccc;
    cursor: pointer;
    background-color: #fff;
}

.fixedtool .current
{
    background-color: #c81623;
    color: #fff;
}
.search-list
{
    height: 1000px;
    /* margin-top: 100px; */
    margin-bottom: 100px;

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
