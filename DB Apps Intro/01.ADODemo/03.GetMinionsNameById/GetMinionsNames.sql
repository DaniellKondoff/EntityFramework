USE MinionsDB

Select m.Name,m.Age from Minions as m
JOIN VillainsMinions as vm
On m.Id=vm.MinionId
Where vm.VillainId=@villainId
