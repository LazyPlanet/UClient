print("Start...")

print("UnityEngine",UnityEngine)

--[[local resMgr = GameObject.Find("ResourceManager"):GetComponent("ResourceManager")

resMgr:LoadAsset("prompt","PromptPanel",function(go)
	warn("load finished",go)
	UnityEngine.Object.Instantiate(go)
end)]]

--[[GameUtil.LoadAsset("prompt","PromptPanel",function(go)
	warn("load finished",go)
	UnityEngine.Object.Instantiate(go)
end)]]

--NetManager:SendConnect("127.0.0.1",2012)
--warn("Connect...")

local function test_login_pb( )
	require "PB.login_pb"
	local login = login_pb.LoginRequest();
    login.id = 2000;
    login.name = 'game';
    login.email = 'jarjin@163.com';

    local msg = login:SerializeToString();
    ----------------------------------------------------------------
    local buffer = LuaGame.ByteBuffer.New();
    buffer:WriteShort(104);
    buffer:WriteByte(1);
    buffer:WriteBuffer(msg);
    NetManager:SendMessage(buffer);
	warn("PB:Send Msg To Server")
end
local function test_login_binary( )
	local buffer = LuaGame.ByteBuffer.New();
	buffer:WriteShort(104);
	buffer:WriteByte(0);
	buffer:WriteString("ffff我的ffffQ靈uuu");
	buffer:WriteInt(200);
	NetManager:SendMessage(buffer);
	warn("Binary:Send Msg To Server")
end

local function test_login_conn()
	local buffer = LuaGame.ByteBuffer.New();
	buffer:WriteShort(104);
	buffer:WriteByte(0);
	buffer:WriteString("ffff我的ffffQ靈uuu");
	buffer:WriteInt(200);
	--NetManager:ConnectToServer("127.0.0.1",2012,buffer)
	NetManager:SendConnect("127.0.0.1",2012)
	warn("Connect Login...")
end

local function show_msgbox(text)
	GameUtil.CreatePanel("MessagePanel",function(panel)
		local lb = panel:AddComponent(LuaBehaviour.GetClassType());
		local mst = {
			onAwake = function(go) warn("awake",go) end,
			--onStart = function() warn("Start panel") end,
			--onDestroy = function() warn("onDestroy") end,
			onClick = function(go)
				if go.name == "Button" then
					UnityEngine.Object.Destroy(panel)
				end
			end,
		}
		lb:TouchGUIMsg(mst);

		local lb_obj = panel.transform:FindChild("Label")
		lb_obj:GetComponent("Text").text = text

		lb_obj:unbind()
	end)
end

local function onItemClick(go)
	warn("onItemClick",go)

	show_msgbox(go.name)
end

local function onCreate(panel)
	local grid = panel.transform:FindChild("ScrollView/Grid")
	local msgHandle = panel:GetComponent("LuaBehaviour")
	GameUtil.LoadAsset("PromptItem","PromptItem",function(g)
		local count = 100; 
		for i = 1, count do
			local go = UnityEngine.Object.Instantiate(g)
			go.name = 'Item'..tostring(i);
			go.transform:SetParent(grid.transform);
			go.transform.localScale = Vector3.one;
			go.transform.localPosition = Vector3.zero;
	        msgHandle:AddClick(go, onItemClick);
	        --msgHandle:AttachEventHandle()
		    local label = go.transform:FindChild('Text');
		    label:GetComponent('Text').text = tostring(i);
		end
		local rtTrans = grid:GetComponent("RectTransform");
		local rowNum = count / 4;
		if count % 4 > 0 then
			rowNum = toInt(rowNum + 1);
			warn("111111111111")
		end
		local size = rtTrans.sizeDelta;
		size.y = rowNum * 100 + (rowNum - 1) * 50;
		rtTrans.sizeDelta = size;

		local position = rtTrans.localPosition;
		position.y = -(size.y / 2);
		rtTrans.localPosition = position;
	end)
end

GameUtil.CreatePanel("PromptPanel",function(panel)
	local lb = panel:AddComponent(LuaBehaviour.GetClassType());
	local mst = {
		onAwake = function(go) warn("awake",go) end,
		--onStart = function() warn("Start panel") end,
		--onDestroy = function() warn("onDestroy") end,
		onClick = function(go)
			if go.name == "Open" then
				if not NetManager.IsConnected then
					test_login_conn()
				else
					test_login_pb()
					test_login_binary()
				end
			end
		end,
	}
	lb:TouchGUIMsg(mst);

	onCreate(panel)
end)




