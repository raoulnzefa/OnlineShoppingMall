<template>
    <div >
    
        <ul class="nav1">
            <li class="li" @click="compare()" :class="{'li-select':sortIndex==1}">综合</li>
            <li class="li" @click="saleTime()" :class="{'li-select':sortIndex==2}">销量</li>
            <li class="li " @click="browseTime()" :class="{'li-select':sortIndex==3}">浏览</li>
            
        </ul>

    
         <div class="product-list" >
             <ul>
                 <li v-for="product in productlist" :key="product.id">
                     <router-link :to="'/ProductDetail?pid='+product.id">
                     <img :src="product.productImageUrl" alt/>
                     <p class="p-price">&yen;{{product.price}}</p>
                     <p class="p-name">{{product.productName}}</p>
                     </router-link>
                 </li>
                 
             </ul>
         </div>
    </div>
   
</template>

<script>
export default {
    data(){
        return{
            productlist:[],
            sortIndex:1,
            searchTxt:null,
            //liIndex:0,
           
            
        };
    },
    mounted(){
        this.getProductList();
       
     
    },
    methods:{
        getProductList(fun){
            var thisVue=this;
            
            this.$http.get("http://localhost:51635/api/Products/GetPhoneProducts").then(function(res){
                thisVue.productlist=res.data;
               thisVue.productlist.forEach(m => {
                   m["compare"]=m.saleTimes*1.5+m.clickTimes
                   
               })
               
               if(fun!=null) fun();
               console.log(thisVue.productlist);

            })

        },
        compare(){
            this.sortIndex=1;
            this.productlist.sort((a,b)=>{
                 return b.compare-a.compare;
             })


        },
        saleTime(){
           
             this.sortIndex=2;
             this.productlist.sort((a,b)=>{
                 return b.saleTimes-a.saleTimes;
             })

        },
        browseTime(){
             this.sortIndex=3;
             this.productlist.sort((a,b)=>{
                 return b.clickTimes-a.clickTimes;
             })

        },
        // search(){
        //     var that=this;
        //     //var searchTxt= document.querySelector("#txtSearch").value;
        //     this.getProductList(function(){
        //         if(that.searchTxt!=null&&that.searchTxt!="")
        //     {
        //          that.productlist=that.productlist.filter(m=>m.productName.includes(that.searchTxt));
        //     }
        //     });
           
           
        // },
        // changeli1(){
        //     this.liIndex=1;
        // },
       
      




    }
};
</script>

<style>

     .nav1{
        
    margin: 40px auto;
     display: flex; 
    height: 30px;
    background-color: #ff8700;
    line-height: 30px;
    cursor: pointer;
     }

     .li{
     float: left;
     display: flex; 
    height: 50px;
    padding: 0 15px;
    color: #fff;
    font-size: 16px;
    font-weight: 500;
    margin-left: 60px;
     }

     .li-select{
         /* color: red; */
         font-weight: bold;
         font-size: 20px;
     }
    .product-list {
        margin: 10px 30px;
        float: left;
    }
     .product-list li{
         float: left;
         width:200px;
         margin:50px 0 0 80px;
         list-style: none;
          border:1px solid transparent;
          padding-bottom: 10px;
     }
     .product-list li:hover{
         border-color:  lightgray;
         box-shadow: 0 0 6px rgb(228, 226, 226);
     }

     .product-list li img{
         width:200px;
         height: 160px;
     }
     .product-list li p{
         text-align: center;
         
     }
    .p-price{
        font-size: 18px;
        font-weight: bold;
        color: red;
        margin-bottom: 4px;
        
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