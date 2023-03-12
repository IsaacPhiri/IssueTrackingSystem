function add(dotnetRef){     
    document.getElementById('h-text').style.color = 'red'
    dotnetRef.invokeMethodAsync("SetValue");
}