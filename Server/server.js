var io = require("socket.io")(1234)

console.log("socket listen to port 1234")

var monsterMaxHP = 200;
var monsterCurHP = monsterMaxHP;
var playerHitHeadDam = 50;
var playerHitBodyDam = 25;
var monsterDied = false;
var monsterDamage = (Math.floor(Math.random() * 6) + 1) * 2;

io.on("connection", (socket) => {

    console.log("Player connect : " + socket.id)

    if(monsterCurHP < monsterMaxHP) {
        updateMonsterData();
    }
    else {
        socket.emit("SpawnMonster", monsterData);
    }

    socket.on("HitHead", () => {

        monsterCurHP -= 50;

        console.log(monsterData.MonsterCurHP);

        updateMonsterData();

        CheckMonsterDied();
    })

    socket.on("HitBody", () => {

        console.lo

        monsterCurHP -= 25;
        
        console.log(monsterCurHP);

        updateMonsterData();

        CheckMonsterDied();
    })

})

var monsterData = {
    MonsterMaxHP : monsterMaxHP,
    MonsterCurHP : monsterCurHP
}

function updateMonsterData() 
{
    var newMonsterData = {
        MonsterMaxHP : monsterMaxHP,
        MonsterCurHP : monsterCurHP
    }

    io.emit("UpdateMonsterData", newMonsterData);
}

function SpawnMonster()
{
    monsterMaxHP = 200;
    monsterCurHP = monsterMaxHP;
    monsterDied = false

    io.emit("EnableImage")
}

function RespawnMonster()
{
    SpawnMonster()
    var monsterData = {
        MonsterMaxHP : monsterMaxHP,
        MonsterCurHP : monsterCurHP
    }
    io.emit("SpawnMonster", monsterData)
}

function WaitForRespawn()
{   
    setTimeout(function ()  {
        RespawnMonster();
        console.log("monster reborn")
    }, 7000);
}

function CheckMonsterDied()
{
    if(monsterCurHP <= 0)
    {
        console.log("Monster died")
        monsterDied = true
        WaitForRespawn();
        io.emit("DisableImage");
    }
    else{
        monsterDied = false
        console.log("monster still alive")
    }
}

    setInterval(() => {
        if(monsterCurHP > 0 && monsterDied == false) {
            var monsterData = {
                MonsterDamage : monsterDamage
            }
            console.log("monster attack")
            io.emit("MonsterAttack", monsterData)
        }
        return;
    }, 5000);