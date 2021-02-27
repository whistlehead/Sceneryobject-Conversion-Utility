import bpy
bpy.ops.wm.collada_import(filepath=r"D:\OneDrive\OMSI\Modelling\Sketchup conversions\K R\DouglasBuilding43.dae")

textures = []
for ob in bpy.data.objects:
    if ob.type == "MESH":
        for mat_slot in ob.material_slots:
            if mat_slot.material:
                for tex_slot in mat_slot.material.texture_slots:
                    textures.append(tex_slot.texture)
                    

file1 = open(r"C:\Users\chris\Desktop\PythonDump.txt","w+")
file1.writelines(textures)
file1.close()

bpy.ops.export_scene.x(filepath=r"D:\OneDrive\OMSI\Modelling\Sketchup conversions\K R\DouglasBuilding43_Temp\DouglasBuilding43.x", SelectedOnly=False, CoordinateSystem='RIGHT_HANDED', UpAxis='Z')
bpy.ops.wm.quit_blender()
