var io = require("socket.io")(1234)

console.log("socket listen to port 1234")

var monsterMaxHP = 1750;
var monsterCurHP = monsterMaxHP;
var playerHitHeadDam = 50;
var playerHitBodyDam = 25;
var monsterDamage = (Math.floor(Math.random() * 6) + 1) * 2;

io.on("connection", (socket) => {
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
    })

    socket.on("HitBody", () => {

        console.lo

        monsterCurHP -= 25;
        
        console.log(monsterData.MonsterCurHP);

        updateMonsterData();
    })

    CheckMonsterDied();

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
    monsterMaxHP = 1750;
    monsterCurHP = monsterMaxHP;
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
    }, 7000);
}

function CheckMonsterDied()
{
    if(monsterCurHP <= 0)
        WaitForRespawn();
}

setInterval(() => {
    if(monsterCurHP > 0) {
        var monsterData = {
            MonsterDamage : monsterDamage
        }
        console.log("monster attack")
        io.emit("MonsterAttack", monsterData)
    }
    return;
}, 1000);