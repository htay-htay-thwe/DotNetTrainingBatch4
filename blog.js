const tblBlog = "blogs";
let blogId = null;

// updateBlog("dfkjasdlfjsdlf","affdsklfjsklf","adkjsaf","adsjk");
// deleteBlog("dfkjasdlfjsdlf");
getBlogTable();


function readBlog(){
    localStorage.getItem();
}

//create Blog
function createBlog(title,author,content){
    const blogs = localStorage.getItem(tblBlog);

    let lst =getBlogs();
const requestModel = {
    id:uuidv4(),
    title:title,
    author:author,
    content:content
};
lst.push(requestModel);
const jsonBlog = JSON.stringify(lst);
localStorage.setItem(tblBlog,jsonBlog);
  getBlogTable();
  clearControl();

}
//end create Blog

//edit Blog
function editBlog(id){
    const blogs = localStorage.getItem(tblBlog);

    let lst =getBlogs();
const items = lst.filter(x => x.id === id);
console.log(items.length);
if(items.length == 0 ){
    console.log("no data found");
    errorMessage("no data found.");
    return;
}
let item = items[0];
blogId = item.id;
$('#txtTitle').val(item.title);
  $('#txtAuthor').val(item.author);
  $('#txtContent').val(item.content);
}

//end edit Blog


//update blog
function updateBlog(id,title,author,content){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst =getBlogs();
const items = lst.filter(x => x.id === id);
if(items.length == 0 ){
    console.log("no data found");
    errorMessage("no data found.");
    return;
}
const item = items[0];
item.title = title;
item.author = author;
item.content = content;
const index = lst.findIndex(x=> x.id === id);
  lst[index] = item;

const jsonBlog = JSON.stringify(lst);
localStorage.setItem(tblBlog,jsonBlog);
}
//end Update blog


//delete Blog
function deleteBlog(id){
    let result = confirm("are you sure want to delete?");
    if(!result) return;
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst =getBlogs();
const items = lst.filter(x => x.id === id);
if(items.length == 0 ){
    console.log("no data found");
    return;
}
lst = lst.filter(x=> x.id !== id);
const jsonBlog = JSON.stringify(lst);
localStorage.setItem(tblBlog,jsonBlog);
getBlogTable();

}
//end delete Blog


function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }


  //get Blog
  function getBlogs(){
    const blogs = localStorage.getItem(tblBlog);
    let lst =[];
   if(blogs !== null){
    lst = JSON.parse(blogs);
    } 
return lst;
  }
  //end get Blogs

 //Save Button
  $('#btnSave').click(function(){
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();
    console.log("...");

    if(blogId === null){
        createBlog(title,author,content)
    }else{
        updateBlog(blogId,title,author,content);
        blogId = null;
    }
    getBlogTable();

  })

  //end save Button

//clear control
  function clearControl(){
  $('#txtTitle').val("");
  $('#txtAuthor').val("");
  $('#txtContent').val("");
  $('#txtTitle').focus();
  }
//end clear control

//get table
function getBlogTable() {
  const lst = getBlogs();
  console.log(lst);
    let count = 0;
    let htmlRows ='';
    lst.forEach(item =>{
        const htmlRow =`
        <tr>
        <th scope="row">${++count}</th>
        <td><button class="btn btn-primary" id="btnSave" onclick="editBlog('${item.id}')">Edit</button>
        <button class="btn btn-danger" id="btnSave" onclick="deleteBlog('${item.id}')">Delete</button></td>
        <td>${item.title}</td>
        <td>${item.author}</td>
        <td>${item.content}</td>
        </tr>`;
        htmlRows += htmlRow;
    });
    $('#tbody').html(htmlRows);
  }
  //end table
