
local UIManager = {}
local MainCanvas = GameObject.Find("Canvas")

function UIManager:OpenUI(UIName, ...)
    local ui = UIConfig[UIName]
    if ui == nil then
        print("UIConfig[" .. UIName .. "] is nil")
        return
    end
    return self:LoadUI(ui.LoadPath, ...)
end

--Resources 加载UI界面
function UIManager:LoadUI(LoadPath, ...)
    local path = LoadPath
    local obj = Resources.Load(path)
    if obj == nil then
        print("Resources.Load[" .. path .. "] is nil")
        return
    end
    local go = GameObject.Instantiate(obj)
    if go == nil then
        print("GameObject.Instantiate[" .. path .. "] is nil")
        return
    end
    go.transform:SetParent(MainCanvas.transform, false)
    return go
end

return UIManager