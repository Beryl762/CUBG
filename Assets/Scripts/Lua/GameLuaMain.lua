require ("Global/Global")

GameLuaMain = {}
function GameLuaMain.Start(self, ...)
	local cube = UnityEngine.GameObject.Find("Cube")
	local cube = UnityEngine.GameObject.Find("Text")
	GameObject.Destroy(cube)
	print("Start")
end

function Update()
end

return GameLuaMain