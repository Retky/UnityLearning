mergeInto(LibraryManager.library, {
  LoadLocalStore: function() {
    try {
      let localStore = localStorage.getItem('scoreBoard');
      myGameInstance.SendMessage('Scoreboard', 'LoadScoreList', localStore);
    }
    catch (e) {
      return "";
    }
  },
  SaveLocalStore: function(jsonString) {
    parseString = UTF8ToString(jsonString);
    console.log(parseString);
    try {
      localStorage.setItem('scoreBoard', parseString);
    }
    catch (e) {
      return false;
    }
    return true;
  }
});
