select a.nombre provincia, count(b.id) cantidad
from Provincia a
inner join Localidad b
on a.id = b.id_Provincia
--where b.Nombre like '%d%'
--and a.Nombre like 'b%'
group by a.Nombre
--having count(b.id) > 20
order by cantidad DESC