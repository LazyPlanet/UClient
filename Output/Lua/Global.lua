PanelManager = LuaGame.PanelManager
ResourceManager = LuaGame.ResourceManager

NetManager = LuaGame.NetworkManager.Instance

function OnReceiveMessage(id,buffer)
	warn("OnReceiveMessage----------------",id,buffer)

	if id == 101 or id == 102 then return end
	local protocal = buffer:ReadByte();
	if protocal ==0 then
		local str = buffer:ReadString();
		warn('protocal:>'..protocal..' str:>'..str);
	elseif protocal == 1 then
		local data = buffer:ReadBuffer();
		local msg = login_pb.LoginResponse();
    	msg:ParseFromString(data);
    	warn('TestLoginPblua: protocal:>'..protocal..' msg:>'..msg.id,msg);
	end
end

