  
  
  这个系统是大学大三下半学期ASP.net这门课的课程设计作品，以下是实验报告，即系统实现详情。
  
  
摘要

英雄联盟资料库系统为广大英雄联盟玩家提供了一个查询游戏数据、资料的平台。该系统界面炫酷，背景是游戏英雄人物原画视频，界面一开就有一股浓重的游戏文化气息。该系统的内容丰富，内容以文字、图片、视频、动画相结合的形式给玩家展示，便于玩家理解。该系统的数据齐全，关于游戏中所涉及的所有文化都有显示，可以查询到关于游戏的一切。而且该系统试试更新数据，官方游戏更新的同时，系统管理员也会及时更新，可以保证用户获得最新最全的资料。

系统概述
========

系统名称
--------

英雄联盟资料库系统

需求分析
--------

当今，网络游戏英雄联盟是最受关注的游戏，这款游戏的玩家超过了1亿。该游戏创造了许多它独特的文化，它包含了141个英雄。英雄名称、背景故事、技能介绍等等都是每个英雄具备的属性。由于英雄的数量庞大以及资料的复杂性，给玩家提供一个随时查询英雄联盟资料的平台显得尤为重要。因此，英雄联盟资料库系统应运而生。

系统功能概述
------------

本系统功能包含了大部分功能，为用户提供了展示英雄列表功能以及展示英雄详细资料功能。针对用户的功能有注册和登录（已加密）功能。针对管理员的功能有对英雄列表信息的增加、删除、修改、查询，如下图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/jiegou.jpg)

​								图 英雄联盟资料库系统结构图

数据库设计
==========

数据库逻辑结构
--------------

### 用户表（User_Table）

用来存储用户信息的表，如下图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/userTable.jpg)

​									图 用户信息表

### 项目表（Item）

用来存储树形目录项目的表，如下图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/itemTable.jpg)
​										图 项目表

### 英雄资料表（Hero_Table）

### 用来存储英雄资料的表，ItemId是外键，与Item表主键对应，(部分)如下图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/heroTable.jpg)

​									图 英雄资料表

数据库连接
----------

### 配置字符连接串

在Web.config的appSettings中配置字符连接串中的服务器和数据库，如图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/config.jpg)

​								图 配置字符连接串

### 字符连接串用户密码加密与解密

使用RSA解密方法对已加密的用户名及密码解密，如图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/config%20(2).jpg)

​								图 解密用户名和密码

### 数据库连接、操作及释放

SqlHelper类已将数据库连接、操作及释放已经封装，里面提供了对数据库的增删改查。

系统设计
========

MVC结构图
---------
![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/mvc.jpg)

​										图 MVC结构图

数据层（Model）
---------------

### Data类

调用SqlHelper类对数据库进行操作：对Item表的增删改查和对Hero_Table表的查询，例如下图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/example.jpg)

​										图 查询例子

### DBUtils类

用来返回字符连接串。

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/getCon.jpg)

​										图 DBUtils

### Security类

RSA加密解密算法，包含两个函数：Encryption实现加密，Decrypt实现解密。

### SqlHelper类

对数据库连接、操作和释放的封装，只需传入字符连接串和查询语句即可于数据库交互。

### TreeView类

>   从数据库获取数据，利用递归来实现有所属关系的字符串。

### Users类

该类包含两个函数：Login和Register。Login负责表单传来的数据与数据库的数据进行比对，看是否满足登录条件；Register负责将表单传来的数据存入数据库。

控制器（Controllers）
---------------------

控制器负责页面与数据层数据的交互。

视图层（View）
--------------

视图层包含五个View，对应5个页面：登录页面、注册页面、首页、英雄详情页、增删改查页

视图层渲染数据（Vue）
---------------------

视图层使用了Vue框架，便于渲染数据。Vue (读音 /vjuː/，类似于 view)
是一套用于构建用户界面的渐进式框架。与其它大型框架不同的是，Vue
被设计为可以自底向上逐层应用。Vue
的核心库只关注视图层，不仅易于上手，还便于与第三方库或既有项目整合。另一方面，当与现代化的工具链以及各种支持类库结合使用时，Vue
也完全能够为复杂的单页应用提供驱动。

视图层接收到控制器传来的数据写入Vue，利用Vue实现与页面的双向数据绑定，Vue中的数据一旦改变，页面的数据也跟着改变。

视图层和控制层的数据传递（Ajax和vue-resource）
----------------------------------------------

该系统放弃了Form表单中的ViewBag传递方式，Vue数据双向绑定，然后通过JQuery的Ajax或者vue中间件vue-resource实现与控制器的数据交互。

vue-resource是一个通过XMLHttpRequrest或JSONP技术实现异步加载服务端数据的Vue插件，提供了一般的
HTTP请求接口和RESTful架构请求接口，并且提供了全局方法和VUe组件实例方法。使用方法类似Ajax。

系统功能详述
============

登录
----

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/login.jpg)

​									图 登录流程图

注册
----

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/register.jpg)

​									图 注册流程图

树形目录
--------
![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/getTreeview.jpg)

​							图 实现树形目录流程图

注：树形目录的实现使用了bootstrap-treeview插件，该插件根据一组json数据返回树形菜单。

增删改查
--------

### 查询

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/getList.jpg)

​									图 查询流程图

### 添加与修改
![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/addAndInsert.jpg)

​									图 添加与修改流程图

### 删除

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/delete.jpg)

​										图 查询流程图

系统实现
========

首页
----

如图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/main.jpg)

​											图 首页

登录页
------

如图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/loginhtml.jpg)
​									图 登录页

### 注册页

如图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/registerhtml.jpg)

​										图 注册页

### 增删改查页

如图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/commandhtml.jpg)

​										图 增删改查页

### 英雄详情页

如图：

![image](https://github.com/HotEmotion/LOL_Database/blob/master/imgFloder/detailhtml.jpg)

​										图 增删改查页


