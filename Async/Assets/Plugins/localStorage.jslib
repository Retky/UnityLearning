mergeInto(LibraryManager.library, {
  Base: function() {
    window.alert('This message was activated from C# to JavaScript');
  },
  NewNum: function() {
    myGameInstance.SendMessage('Text Controller', 'AutoChangeText');
  },
  DelayNum: function() {
    setTimeout(function() {
      myGameInstance.SendMessage('Text Controller', 'AutoChangeText');
    }, 1000);
  },
  SaveToLocal: function(str) {
    const parseString = UTF8ToString(str);
    localStorage.setItem('gameString', parseString);
  },
  TextFromPlugin: function() {
    myGameInstance.SendMessage('Text Controller', 'ChangeText', 'This text is from JavaScript');
  },
  LoadFromLocal: function() {
    try {
      let str = localStorage.getItem('gameString');
      myGameInstance.SendMessage('Text Controller', 'ChangeText', str);
    } catch (e) {
      console.log(e.message);
      return '';
    }
  }
});
