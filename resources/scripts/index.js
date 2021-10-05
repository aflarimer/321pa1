var tweets = ["Hey, it's Big Al", "Me again", "42-21!"];

function setGreets() {
    var html = "<ul>";
    tweets.forEach((tweet)=>{
        html += "<li><div class=\"avatar\"></div><span>"+tweet+"</span></li>"
    });
        html += "</ul>";
        document.getElementById("greets").innterHTML = html;
}

function handleOnLoad() {
    setGreets();
}

addPost = function() { //add to list then call setGreets again to get it on website
    let postText = document.getElementById("post").value;
    tweets.push(postText);
    setGreets();
}

function handleOnSubmit() {
    addPost();
}