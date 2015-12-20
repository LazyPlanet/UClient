print("Start...")

print("UnityEngine",UnityEngine)

local GameObject = UnityEngine.GameObject

local obj = GameObject.New("Hello")

warn("obj",obj,obj.name)

UnityEngine.Object.Destroy(obj)

warn("obj2",obj,obj.isNil)

warn(LuaGame.ByteBuffer)

local buff = LuaGame.ByteBuffer.New()
warn("buff",buff)

--luanet.free_object(buff)

warn(buff)
buff:unbind()
warn(buff,buff.isNil)
warn("LuaGame.ByteBuffer",LuaGame.ByteBuffer)

warn("LuaUtil",LuaUtil.GetType("Button"),LuaUtil.GetType("UI.Button"))


--[[local resMgr = GameObject.Find("ResourceManager"):GetComponent("ResourceManager")

resMgr:LoadAsset("prompt","PromptPanel",function(go)
	warn("load finished",go)
	UnityEngine.Object.Instantiate(go)
end)]]

--[[GameUtil.LoadAsset("prompt","PromptPanel",function(go)
	warn("load finished",go)
	UnityEngine.Object.Instantiate(go)
end)]]
local NetManager = LuaGame.NetworkManager.Instance

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
	NetManager:ConnectToServer("127.0.0.1",2012,buffer)
	--NetManager:SendConnect("127.0.0.1",2012)
	warn("Connect Login...")
end

GameUtil.CreatePanel("PromptPanel",function(panel)
	local LuaBehaviour = LuaGame.LuaBehaviour
	local lb = panel:AddComponent(LuaBehaviour.GetClassType());
	local mst = {
		onAwake = function(go) warn("awake",go) end,
		--onStart = function() warn("Start panel") end,
		--onDestroy = function() warn("onDestroy") end,
		onClick = function(go)
			if not NetManager.IsConnected then
				test_login_conn()
			else
				test_login_pb()
				test_login_binary()
			end
		end,

	}
	lb:TouchGUIMsg(mst);
end)




