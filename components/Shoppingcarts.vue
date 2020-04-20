<template>
	<div>
		<p class="p-title w">我的购物车</p>
		<!--描述：显示菜单开始-->		
		<div class="tips w">
						
			<ul>				
				<li><input type="checkbox" @click="checkallin()" v-model="checkall" />全选</li>				
				<li>商品</li>				
				<li>单价</li>				
				<li>数量</li>				
				<li>小计</li>				
				<li>操作</li>			
			</ul>		
		</div>			
		<!--描述：显示菜单结束-->
		<!--描述：商品详情展示开始-->		
		<div >			
			 <!-- :key="chart.id" v-model="selectproduct"-->
			<ul class="info w"  v-for="(chart,index) in cartlists" :key="chart.id">		
				<li class="info_1"><input type="checkbox" :value="chart.id"  v-model="selectproduct"  @click="selectpro(chart.id)" /></li>				
				<li class="info_2"><img :src="chart.productImage"  width="80px"/></li>				
				<li class="info_3" >{{chart.productName}}</li>							
				<li class="info_5">{{chart.price}}</li>				
				<li class="info_6">					
					<button @click="btn_minute(index)">-</button>					
					<input :value="chart.count" />					
					<button class="but" @click="add(index)">+</button>				
				</li>				
				<li class="info_7">￥{{chart.price*chart.count}}</li>				
				<li class="info_8" @click="remove(chart.id,index)">删除</li>
				 <!-- @click="remove(index)			 -->
			</ul>		
		</div>
		<!--描述：商品详情展示结束-->				
		
		<!--描述：商品结算开始-->		
		<div class="balance w">			
			<ul class="balance_ul1">							
				<li style="color: #c81623;cursor: pointer;margin-left:20px" @click="removeall()">删除选中商品</li>							
			</ul>						
			<ul class="balance_ul2">				
				<li>已经选择<span>{{sum}}</span>件商品</li>				
				<li>总价<span>￥{{totalprice}}</span></li>				
				<li><button class="butt">去结算</button></li>			
			</ul>		
		</div>		
		<!--描述：商品结算结束-->



	</div>
</template>
<script>
import axios from 'axios';
export default {
	data(){
		 return{
			cartlists:[],
			selectproduct:[],
			totalprice:0,
			sum:0,
			checkall:false,//全选按钮
			
        }


	},
	
	mounted(){
		this.getChart();
        
	},
	
	methods:{
		 getChart:function () {
             var thisVue=this;
            this.$http.get("http://localhost:51635/api/Products/GetShoppingcarts").then(function(res){
                thisVue.cartlists=res.data;  
            });
                  
		},
		btn_minute: function(index){
			if (this.cartlists[index].count === 1) return;
				 this.cartlists[index].count--;
		   this.gettotal();
		},
		add:function(index)
		{
			this.cartlists[index].count++;
			this.gettotal();
		},
		
		remove:function(id,index){
			 if(this.selectproduct.includes(id))
                {
                    for(let i=0;i<this.selectproduct.length;i++)
                    {
                        const curried=this.selectproduct[i];
                        if(curried==id)
                        {
							this.selectproduct.splice(i,1);
                        }
                    }
                }
			this.cartlists.splice(index,1);
			this.gettotal();
		//	this.$store.commit("removeFromChart",id);

		},
		
		gettotal(){
			
				var tprice=0;
				var numb = 0;
                for (let i = 0; i< this.selectproduct.length; i++) {
				  const cid = this.selectproduct[i];				   
                  var cart=this.cartlists.filter(m=>m.id==cid)[0];
				  tprice+=cart.price*cart.count;
				  numb+=cart.count;                  
				}
				this.sum=numb;
				console.log(numb);
				this.totalprice=tprice.toFixed(2);

			
			},
		 selectpro(cid){ 			    		           
                if(this.selectproduct.includes(cid))
                {
                    for(let i=0;i<this.selectproduct.length;i++)
                    {
                        const curried=this.selectproduct[i];
                        if(curried===cid)
                        {
							this.selectproduct.splice(i,1);
                        }
                    }
                }
				else{ this.selectproduct.push(cid);		
				}
				               
				
				//this.sum=sum2;
              this.gettotal();
				console.log(this.selectproduct)
			    
			},
				
		 checkallin(){
			  var _this = this
    //true的时候是全选，false是不选
    if(this.checkall) {
      // 实现反选，按钮选中时 实现了反选，列表为空
      this.selectproduct = []
      this.totalprice=0;
      this.sum=0;
    } else {
      // 实现全选
        this.totalprice=0;
      this.sum=0;
      this.selectproduct = []
      this.cartlists.forEach(function(chart) {
        _this.totalprice+=parseInt(chart.price);
        _this.sum+=parseInt(chart.count);
        _this.selectproduct.push(chart.id)
      })
    }
    if(this.selectproduct.length === this.cartlists.length) {
      this.checkall = true
      // console.log(this.checkall)
      // console.log(this.checked)
    }

		 },
		removeall(){
			for(var i=this.cartlists.length-1;i>=0;i--)
			{
				 if(this.selectproduct.includes(this.cartlists[i].id))
                {
                    
					this.selectproduct.splice(i,1);
                    this.cartlists.splice(i,1);
                    
                }
			}
			this.gettotal();
              
		}
	},
	
}
</script>
<style scoped>
.p-title
{
	/* float: left; */
	margin-top:50px;
	margin-bottom: 10px;
	font-size: 23px;
	color: #c91623;
}
.tips
{
   width: 1200px;
   height: 50px;
   background-color: #f1f1f1;
   margin-top: 15px;
   border: 1px  solid  #e9e9e9;
}
.tips li{
	float: left;
	line-height: 50px;
	font-size: 13px;
	color: gray;
}
.tips li:nth-child(1)
{	
	width: 120px;	
	border-top: 3px solid #c91623;
	text-align: center;
	}
.tips li:nth-child(2)
{	
	margin-left: 100px;	
	} 
.tips li:nth-child(3)
{	margin-left: 430px;	} 
.tips li:nth-child(4
){	
	margin-left: 110px;	
	} 
.tips li:nth-child(5){
	margin-left: 110px;	} 
.tips li:nth-child(6){	
	margin-left: 110px;	}
/*描述：显示菜单结束*/
/*描述：商品详情展示开始*/
.info{
	width: 1200px;
	height: 125px;
	background-color: #fff4e8;
	border: 1px solid gray;
	margin-top: 25px;
}
.info li{		
	float: left;	
	margin-top: 35px;} 
.info_1{	
	margin-left:40px;} 
.info_2{	
	margin-left:90px;	
	/* border: 1px solid gray; */
	} 
.info_3{	
	width: 260px;	
	height: 20px;}

.info_5{	
	width: 220px;
	text-align:right;
}
	/* margin-left:190px;} */
.info_6{	margin-left:80px;}
.info_6 input{	
	width: 30px;	
	height: 18px;	
	position: relative;
	text-align: center;	
	top: -1px;	
	left: -5px;}
.but{	
	position: relative;	
	left: -10px;}
.info_6 button{	 
	width: 30px;	 	 
	height: 18px;}
.info_7{	
	width: 100px;
	text-align: right;}
	/* margin-left:60px;} */
.info_8{	
	margin-left:100px;
	color: #c81623;
	cursor: pointer;}

/*描述：商品结算开始*/
.balance{	
	width: 1200px;	
	height: 50px;	
	border: 1px solid gray;	
	margin-top: 20px;}
.balance li{	
	float: left;	
	line-height: 50px;	
	margin-left: 40px;}
.balance_ul2{	float: right;	}
.balance_ul2 span{	
	font-size: 25px;	 	
	color: #C91623 ;		
	font-weight: bold;}
.balance_ul2 button{	
	width: 100px;	
	height: 47px;	
	background-color: brown;	
	border: 1px solid #c91623; 	 
	font-weight: 47px;	
	font-size: 20px;	
	color: white;}
.balance_ul2 button:hover{	background-color:#C91623 ;}


</style>