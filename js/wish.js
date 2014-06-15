var tagEle = "querySelectorAll" in document ? document.querySelectorAll(".tag") : getClass("tag"),
            paper = "querySelectorAll" in document ? document.querySelector(".tagBall") : getClass("tagBall")[0];
RADIUS = 220,
fallLength = 500,
tags = [],
angleX = Math.PI / 500,
angleY = Math.PI / 500,
CX = paper.offsetWidth / 2,
CY = paper.offsetHeight / 2-35,
EX = paper.offsetLeft + document.body.scrollLeft + document.documentElement.scrollLeft,
EY = paper.offsetTop + document.body.scrollTop + document.documentElement.scrollTop;

function getClass(className) {
    var ele = document.getElementsByTagName("*");
    var classEle = [];
    for (var i = 0; i < ele.length; i++) {
        var cn = ele[i].className;
        if (cn === className) {
            classEle.push(ele[i]);
        }
    }
    return classEle;
}

function innit() {
    $("BackPart").onclick = closePopBlog;
    $("addWish").onclick = function () {
        popAddWish();
    }
    for (var i = 0; i < tagEle.length; i++) {
        var a, b;
        var k = (2 * (i + 1) - 1) / tagEle.length - 1;
        var a = Math.acos(k);
        var b = a * Math.sqrt(tagEle.length * Math.PI);
        var x = RADIUS * Math.sin(a) * Math.cos(b);
        var y = RADIUS * Math.sin(a) * Math.sin(b);
        var z = RADIUS * Math.cos(a);
        var t = new tag(tagEle[i], x, y, z);
        tagEle[i].style.color = "rgb(" + parseInt(Math.random() * 255) + "," + parseInt(Math.random() * 255) + "," + parseInt(Math.random() * 255) + ")";
        tags.push(t);
        t.move();
    }
}

Array.prototype.forEach = function (callback) {
    for (var i = 0; i < this.length; i++) {
        callback.call(this[i]);
    }
}

function animate() {
    setInterval(function () {
        rotateX();
        rotateY();
        tags.forEach(function () {
            this.move();
        })
    }, 50)
}

if ("addEventListener" in window) {
    paper.addEventListener("mousemove", function (event) {
        var x = event.clientX - EX - CX;
        var y = event.clientY - EY - CY;
        // angleY = -x* (Math.sqrt(Math.pow(x , 2) + Math.pow(y , 2)) > RADIUS/4 ? 0.0002 : 0.0001);
        // angleX = -y* (Math.sqrt(Math.pow(x , 2) + Math.pow(y , 2)) > RADIUS/4 ? 0.0002 : 0.0001);
        angleY = x * 0.0001;
        angleX = y * 0.0001;
    });
}
else {
    paper.attachEvent("onmousemove", function (event) {
        var x = event.clientX - EX - CX;
        var y = event.clientY - EY - CY;
        angleY = x * 0.0001;
        angleX = y * 0.0001;
    });
}

function rotateX() {
    var cos = Math.cos(angleX);
    var sin = Math.sin(angleX);
    tags.forEach(function () {
        var y1 = this.y * cos - this.z * sin;
        var z1 = this.z * cos + this.y * sin;
        this.y = y1;
        this.z = z1;
    })

}

function rotateY() {
    var cos = Math.cos(angleY);
    var sin = Math.sin(angleY);
    tags.forEach(function () {
        var x1 = this.x * cos - this.z * sin;
        var z1 = this.z * cos + this.x * sin;
        this.x = x1;
        this.z = z1;
    })
}

var tag = function (ele, x, y, z) {
    this.ele = ele;
    this.x = x;
    this.y = y;
    this.z = z;
}

tag.prototype = {
    move: function () {
        var scale = fallLength / (fallLength - this.z);
        var alpha = (this.z + RADIUS) / (2 * RADIUS);
        this.ele.style.fontSize = 15 * scale + "px";
        this.ele.style.opacity = alpha + 0.5;
        this.ele.style.filter = "alpha(opacity = " + (alpha + 0.5) * 100 + ")";
        this.ele.style.zIndex = parseInt(scale * 100);
        this.ele.style.left = this.x + CX - this.ele.offsetWidth / 2 + "px";
        this.ele.style.top = this.y + CY - this.ele.offsetHeight / 2 + "px";
    }
}
innit();
animate();

function closePopBlog() {
    if (document.getElementById("popapp_cnt") != null) {
        document.body.removeChild(document.getElementById("popapp_cnt"));
        document.getElementById("BackPart").style.display = "none";
    }
}

function popAddWish() {
    if (document.getElementById("popapp_cnt") != null) {
        document.body.removeChild(document.getElementById("popapp_cnt"));
        return;
    }

    var top = 100;
    var left = document.documentElement.scrollLeft + document.body.scrollLeft + document.documentElement.clientWidth / 2-270;


    var inject = document.createElement("div");
    inject.className = "detail-tip shadow-right";
    inject.id = "popapp_cnt";
    inject.style.cssText = "left:" + left + "px;top:" + top + "px;background-color:#CCCCCC;";
    inject.innerHTML = createAddWishStr();
    document.body.appendChild(inject);
    $("wishcontent").focus();
    document.getElementById("BackPart").style.display = "block";
}

function createAddWishStr() {
    var htmlstr = "<div class='wishPop'><div class='wishContent'><input id='wishtime' type='text'/><input id='wishcontent' type='text'/><span type='button' id='span_addwish' onclick='addWish()'></span></div><div>";
    return htmlstr;
}

function addWish() {
    var content = $("wishcontent").value;
    var time = $("wishtime").value;
    var request = 'Ajax/Ajax_Wish.aspx';
    var senddata = 'o=a&content=' + content + "&rt=" + time;
    xmlHttpRequest = createXmlHttpRequest();

    xmlHttpRequest.onreadystatechange = function () {
        if (xmlHttpRequest.readyState == 4 && xmlHttpRequest.status == 200) {
            var b = xmlHttpRequest.responseText;
            if (b != "-1") {
                alert("添加成功！");
                document.location.reload();
            } else {
                alert("添加失败！");
            }
        }
    };


    //3.初始化XMLHttpRequest组建    
    xmlHttpRequest.open("POST", request, true);
    xmlHttpRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    //4.发送请求    
    xmlHttpRequest.send(senddata);
}
