require ("Global/Global")

GameLuaMain = {}
function GameLuaMain.Start(self, ...)
	print("Start")
	UIManager:OpenUI(UIConfig.StartPanel.Name)
end

function Update()
end

return GameLuaMain