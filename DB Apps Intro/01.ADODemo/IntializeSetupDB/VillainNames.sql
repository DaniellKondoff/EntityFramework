Select v.Name,COUNT(vm.MinionId) as MinionsCount from Villains as v
JOIN VillainsMinions as vm
ON v.Id=vm.VillainId
Group By v.Name
Having COUNT(vm.MinionId) >3
Order By MinionsCount DESC