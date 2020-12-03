create table card_main
(
	seq int identity(1,1) not null primary key,
	card_level char(1) not null default '1', -- 0:legend 1:epic 
	card_name varchar(200) not null,
	card_passive1 varchar(200) null,
	card_passive2 varchar(200) null,
	card_basic_health int default 0,
	card_basic_strong1 int default 0,
	card_basic_defense int default 0,
	card_basic_strong2 int default 0,		
	card_etc varchar(3000) null,
	card_effect_attack decimal(4,3) default 0,
	card_effect_defense decimal(4,3) default 0,
	card_effect_defense_minus decimal(4,3) default 0
)

drop table card_main

select * from card_main
order by card_level, case when card_etc = '������' then 0 when card_etc = '����' then 1 when card_etc = '����' then 2 else 9 end, card_name

insert into card_main values
('1', '��Ű����', '�Ϲݰ������� 1750', 'ü�� 3750', 3600, 810, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', 'Ŭ����ư���', '�Ϲݰ������� 1250', 'ü�� 6250', 3600, 810, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '���������', 'ü�� 6250', 'ī�� ���ݷ� 250', 3600, 510, 1875, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('0', '�׶�þ�', '���� 2500�� ����', '', 5600, 560, 1200, 122, '������', 0, 0, 0)

insert into card_main values
('0', '��Ƽ��', '�Ϲݰ������عݻ� 30%', '', 3800, 560, 2100, 122, '������', 0, 0, 0.3)

insert into card_main values
('0', '�ƽ�Ÿ��Ʈ', '�������۽� 12000 ����', '', 3800, 920, 1200, 122, '������', 0, 0, 0)

insert into card_main values
('0', '������', '�Ϲݰ��ݽ� 30% ��ŭ ����', '', 5600, 560, 1200, 122, '������', 0, 0, 0)

insert into card_main values
('0', '���ҿ÷���', '���ݽ� ��� 100%��ŭ �߰�����', '', 3800, 560, 2100, 122, '������', 0, 0, 0)

insert into card_main values
('1', '�����Ǹ�������', '�����ȿ�� 20%', '�Ϲݰ������� 16.8%', 3600, 510, 1075, 172, '����', 0.2, 0.2, 0)

insert into card_main values
('1', '��÷���׼�°��', '�Ϲݰ������� 15%', '���ݷ� 1250', 3600, 810, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '������Ÿ', '�����ȿ�� 20%', '�������ذ��� 17.3%', 3600, 510, 1075, 172, '����', 0.2, 0.2, 0.173)

insert into card_main values
('1', '�����', '�Ϲݰ��ݽ� 30% �߰���������', '', 3600, 810, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '�����', '���ݽ� 50%Ȯ���� 5000 �߰�����', '', 3600, 510, 1075, 172, '����', 0, 0, 0)

insert into card_main values
('1', '��ź������������', '�����ȿ�� 20%', '���ݷ� 1500', 3600, 810, 1075, 112, '����', 0.2, 0.2, 0)

insert into card_main values
('1', '���Ǽ��׵�°��', '���ݽ� 2500 �߰�����', '', 5100, 510, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '�ÿ�����������', '�������ذ��� 15%', 'ü�� 7000', 5100, 510, 1075, 112, '����', 0, 0, 0.15)

insert into card_main values
('1', '�������', '������� 23%', '���������� 14.6%', 3600, 510, 1825, 112, '����', 0.376, 0, 0)

insert into card_main values
('1', '���丣��', '���Ӱ��ݽ� 70% ����', '', 3600, 810, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '�����������', '���������� 13%', '���ݷ� 1400', 3600, 810, 1075, 112, '����', 0.13, 0, 0)

insert into card_main values
('1', 'Ƽ�ϻ߿���', '�������ذ��� 15%', '���������� 15.6%', 5100, 510, 1075, 112, '����', 0.156, 0, 0.15)

insert into card_main values
('1', 'Ǫ������û��', '���������� 18.2%', 'ü�� 4500', 5100, 510, 1075, 112, '����', 0.182, 0, 0)

insert into card_main values
('1', 'Ǫ��20��', '�Ϲݰ������� 1250', '�������ذ��� 15%', 3600, 510, 1825, 112, '����', 0, 0, 0.15)

insert into card_main values
('1', 'Ǫ��6��', '�������ذ��� 15%', 'ü�� 6250', 3600, 810, 1075, 112, '����', 0, 0, 0.15)

insert into card_main values
('1', '�غ��ǹٹٶ�', 'ü�� 6250', 'ī����ݷ� 280', 3600, 510, 1075, 172, '����', 0, 0, 0)

insert into card_main values
('1', '�غ���Ŭ�����', 'ü�� 6250', '���ݷ� 1400', 3600, 810, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '����', '�����ȿ�� 20%', '���������� 14.6%', 5100, 510, 1075, 112, '����', 0.346, 0.2, 0)

insert into card_main values
('1', '���ݶ�', '���������� 15.6%', '���� 3000', 5100, 510, 1075, 112, '����', 0.156, 0, 0)

insert into card_main values
('1', '�����ڵ��ĭ', 'ī����ݷ� 400', '���������� 6%', 3600, 510, 1075, 172, '�Ϲ�', 0.06, 0, 0)

insert into card_main values
('1', '���׸�', '���ݷ� 2000', '���������� 6%', 3600, 810, 1075, 112, '����', 0.06, 0, 0)

insert into card_main values
('1', '�Ѷ�', '���������� 15.6%', '�Ϲݰ������� 12%', 5100, 510, 1075, 112, '����', 0.156, 0, 0)

insert into card_main values
('1', '����', '���ݷ� 2500', '', 5100, 510, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '�ñ׷�', '���� 6625', '', 3600, 510, 1825, 112, '����', 0, 0, 0)

insert into card_main values
('1', '��������', '�Ϲݰ������� 2500', '', 3600, 510, 1075, 172, '����', 0, 0, 0)

insert into card_main values
('1', 'ī������', '�����ȿ�� 40%', '', 5100, 510, 1075, 112, '����', 0.4, 0.4, 0)

insert into card_main values
('1', '��Ʈ����', '���������� 26%', '', 3600, 810, 1075, 112, '����', 0.26, 0, 0)

insert into card_main values
('1', '�ǿ���', 'HP�� 60% �����϶� �Ϲݰ������� 60%', '', 5100, 510, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '�췹�̽�', 'ü�� 12500', '', 3600, 510, 1075, 172, '����', 0, 0, 0)

insert into card_main values
('1', 'Ȳ��ٹٶ�', 'ī����ݷ� 500', '', 3600, 510, 1825, 112, '����', 0, 0, 0)

insert into card_main values
('1', '�����', '���������� 7.8%', '�Ϲݰ������� 1900', 5100, 510, 1075, 112, '����', 0.078, 0, 0)

---------------

insert into card_main values
('1', '��Ÿ���', '���� 25%', '�Ϲݰ������� 15%', 3600, 510, 1075, 172, '����', 0, 0, 0)

insert into card_main values
('1', '����Ǻ�����', '���� 3125', 'ī����ݷ� 250', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '��������ũ��', '�������ذ��� 30%', '', 3600, 810, 1075, 112, '�Ϲ�', 0, 0, 0.3)

insert into card_main values
('1', '�����Ʈ����ũ', 'ü�� 6250', '���� 3125', 3600, 810, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '������緷', '�Ϲݰ������� 30%', '', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '���', '�Ϲݰ������� 15%', '�Ϲݰ������� 1250', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '�׷�����', '�Ϲݰ������� 1250', 'ī����ݷ� 250', 3600, 510, 1075, 172, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '���񿩿պ�����', '�������ذ��� 21%', 'ī����ݷ� 150', 3600, 510, 1825, 112, '�Ϲ�', 0, 0, 0.21)

insert into card_main values
('1', '����ī', '���������� 13%', '�������ذ��� 15%', 3600, 810, 1075, 112, '�Ϲ�', 0.13, 0, 0.15)

insert into card_main values
('1', '�븶�������', '������� 46%', '', 3600, 510, 1075, 172, '�Ϲ�', 0.46, 0, 0)


---------------------------------

insert into card_main values
('1', '���������', '���� 20%', '���ݷ� 30%', 3600, 810, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '����Ÿ', '���������� 13%', '�Ϲݰ������� 1250', 3600, 810, 1075, 112, '�Ϲ�', 0.13, 0, 0)

insert into card_main values
('1', '�����', '�������ذ��� 24%', '���� 1250', 3600, 510, 1825, 112, '�Ϲ�', 0, 0, 0.24)

insert into card_main values
('1', '���㿩�ո�����ī', '�Ϲݰ������� 21%', 'ü�� 3750', 3600, 510, 1075, 172, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '�ҵ巹��ũ', '���� 25%', '������� 23%', 3600, 810, 1075, 112, '�Ϲ�', 0.23, 0, 0)

insert into card_main values
('1', '�������', '���������� 18.2%', 'ü�� 3750', 5100, 510, 1075, 112, '�Ϲ�', 0.182, 0, 0)

insert into card_main values
('1', '��Į��', '���������� 18.2%', 'ü�� 3750', 5100, 510, 1075, 112, '�Ϲ�', 0.182, 0, 0)

insert into card_main values
('1', '�긮�Ǵ�', '�������ذ��� 15%', '���ݷ� 1250', 5100, 810, 1075, 112, '�Ϲ�', 0, 0, 0.15)

insert into card_main values
('1', '����ũ', '���������� 13%', 'ī����ݷ� 250', 5100, 510, 1075, 112, '�Ϲ�', 0.13, 0, 0)

insert into card_main values
('1', '�þ', 'ü�� 3750', '���ݷ� 1750', 3600, 810, 1075, 112, '�Ϲ�', 0, 0, 0)


insert into card_main values
('1', '����Ų���', '�Ϲݰ������� 15%', 'ī����ݷ� 25%', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '�̸��', '���������� 13%', 'ü�� 6250', 3600, 810, 1075, 112, '�Ϲ�', 0.13, 0, 0)


insert into card_main values
('1', 'í�ٳ�', '���������� 20.8%', 'ī����ݷ� 100', 3600, 510, 1075, 172, '�Ϲ�', 0.208, 0, 0)

insert into card_main values
('1', 'Ķ����', '���������� 13%', '���ݷ� 1250', 5100, 510, 1075, 112, '�Ϲ�', 0.13, 0, 0)

insert into card_main values
('1', 'ũ����Ż', '�Ϲݰ������� 24%', 'ī����ݷ� 100', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', 'ũ��Ų��', '�Ϲݰ������� 15%', '������� 23%', 3600, 510, 1075, 172, '�Ϲ�', 0.23, 0, 0)



insert into card_main values
('1', 'Ʈ����ũ', '�Ϲݰ������� 15%', '�������ذ��� 15%', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0.15)

insert into card_main values
('1', '�ı����ǹ����', '���ݷ� 1250', '���� 3125', 3600, 810, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '�緷', '�������ذ��� 15%', '������� 23%', 3600, 810, 1075, 112, '�Ϲ�', 0.23, 0, 0.15)

insert into card_main values
('1', 'Ǫ��13��', '�Ϲݰ������� 18%', '���ݷ� 20%', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '��������', 'ü�� 2500', '�������ذ��� 24%', 5100, 510, 1075, 112, '�Ϲ�', 0, 0, 0.24)

insert into card_main values
('1', '����������', '�Ϲݰ������� 1250', '���� 3125', 3600, 510, 1825, 112, '�Ϲ�', 0, 0, 0)

insert into card_main values
('1', '����', '���������� 18.2%', '���� 1875', 3600, 510, 1075, 172, '�Ϲ�', 0.182, 0, 0)

insert into card_main values
('1', '�ĵ�������̸�', '���������� 15.6%', 'ī����ݷ� 250', 3600, 510, 1075, 172, '����', 0.156, 0, 0)

insert into card_main values
('1', '����ũ����Ż', '���ݷ� 1250', '���������� 15.6%', 3600, 810, 1075, 112, '����', 0.156, 0, 0)

insert into card_main values
('1', '���׵�Ʈ', '�������ذ��� 21%', 'ī����ݷ� 200', 3600, 510, 1825, 112, '����', 0, 0, 0.21)

insert into card_main values
('1', 'ī�ڹ̸�', 'ü�� 7000', 'ī�� ���ݷ� 250', 5100, 510, 1075, 112, '����', 0, 0, 0)

insert into card_main values
('1', '�ϸ��', 'ī����ݷ� 550', '', 3600, 510, 1075, 172, '����', 0, 0, 0)


---------------------------------------

create table card_user
(
	seq int identity(1,1) not null primary key,
	u_id varchar(1000) not null,
	u_pwd varchar(255) not null,
	cre_date datetime default getdate()
)

select * from card_user where u_id = 'test' and u_pwd = 'test'
insert into card_user values ('test','test', GETDATE())

create table card_battle_main
(
	subseq int identity(1,1) not null primary key,
	seq int not null,
	battle_name varchar(2000),
	card_name varchar(200),
	card_level varchar(100),
	skill_1 varchar(200),
	skill_2 varchar(200),
	ai_name varchar(200),
	defense_per varchar(255),
	stat_health int default 0,
	stat_strong1 int default 0,
	stat_defense int default 0,
	stat_strong2 int default 0,
	sword1 float default 0,
	sword2 float default 0,
	sword3 float default 0,
	sword4 float default 0,
	sword5 float default 0,
	effect_atk float default 0,
	effect_def float default 0,
	cre_date datetime default getdate()
)

select * from card_user
where u_id = 'usaki'

select * from card_battle_main a inner join 
(
	select seq from card_user
	where u_id = 'usaki'
) b on a.seq = b.seq
where ai_name is not null
order by subseq desc

select * from card_battle_main a inner join 
(
	select seq from card_user
	where u_id = 'usaki'
) b on a.seq = b.seq
and a.battle_name = ''
select * From card_battle_main where seq = 1
insert into card_battle_main values 
(1, '��Ű�׽�Ʈ', '��Ű����', '100', '�ҹ�', 'ȭ��', '���ֲ�1', 
30000, 6000, 5000, 400,
4000, 7500, 9000, 10000, 14000,
0, 0, getdate())

insert into card_battle_main
select
	seq, 
	'�׽�Ʈ',
	'����',
	'100',
	'',
	'',
	'',
	30000, 6000, 5000, 400,
	4000, 7500, 9000, 10000, 14000,
	0, 0, GETDATE()
from card_user
where u_id = 'usaki'

create table card_AIList
(
	seq int identity(1,1) not null primary key,
	ai_name varchar(255) not null,
	first1 varchar(50) null,
	first2 varchar(50) null,
	first3 varchar(50) null,
	first4 varchar(50) null,
	cre_date datetime default getdate()
)

insert into card_AIList values ('������ ���ֲ�', '��ų1','��','��ų2','��', GETDATE())
insert into card_AIList values ('����� ���ֲ�', '��ų1','��','��ų2','��', GETDATE())
insert into card_AIList values ('�ϴ� ��ƾ���', '��','��ų1','��ų2','��', GETDATE())
insert into card_AIList values ('ũ�� �븰��', '��','��ų1','��ų2','��', GETDATE())
select * from card_AIList

create table card_shuffle_active
(	
	subseq int identity(1,1) not null primary key,
	seq int not null,
	s_type varchar(50) not null,
	shuffle varchar(50) not null
)

insert into card_shuffle_active values (3, 'LEFT', '��')
insert into card_shuffle_active values (3, 'LEFT', '��')
insert into card_shuffle_active values (3, 'LEFT', '��')
insert into card_shuffle_active values (3, 'LEFT', '��')
insert into card_shuffle_active values (3, 'LEFT', '��')

insert into card_shuffle_active values (3, 'RIGHT', '��')
insert into card_shuffle_active values (3, 'RIGHT', '��')
insert into card_shuffle_active values (3, 'RIGHT', '��')

insert into card_shuffle_active
select seq, 'RIGHT', '��' from card_user where u_id = 'usaki'

select * from card_shuffle_active order by s_type

select	
	shuffle, COUNT(shuffle) as cnt
from card_shuffle_active where seq = 3 and s_type = 'LEFT'
group by shuffle

select	
	shuffle, COUNT(shuffle) as cnt
from card_shuffle_active where seq = 3 and s_type = 'RIGHT'
group by shuffle

delete from card_shuffle_active where subseq in (
	select subseq from (
		select top 2 subseq from card_shuffle_active where seq in (select seq from card_user where u_id = 'usaki') 
		and s_type = 'LEFT' and shuffle = '��'
	) a
)

select * From card_user
select * from card_battle_main
select * from card_shuffle_active