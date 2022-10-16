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
});
