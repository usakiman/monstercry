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
order by card_level, case when card_etc = '레전드' then 0 when card_etc = '한정' then 1 when card_etc = '투기' then 2 else 9 end, card_name

insert into card_main values
('1', '발키르잔', '일반공격피해 1750', '체력 3750', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '클라우디아공주', '일반공격피해 1250', '체력 6250', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '레지나루노', '체력 6250', '카드 공격력 250', 3600, 510, 1875, 112, '일반', 0, 0, 0)

insert into card_main values
('0', '그라시아', '매턴 2500씩 피해', '', 5600, 560, 1200, 122, '레전드', 0, 0, 0)

insert into card_main values
('0', '레티르', '일반공격피해반사 30%', '', 3800, 560, 2100, 122, '레전드', 0, 0, 0.3)

insert into card_main values
('0', '아스타로트', '전투시작시 12000 피해', '', 3800, 920, 1200, 122, '레전드', 0, 0, 0)

insert into card_main values
('0', '알폰스', '일반공격시 30% 만큼 흡혈', '', 5600, 560, 1200, 122, '레전드', 0, 0, 0)

insert into card_main values
('0', '제롬올렌더', '공격시 방어 100%만큼 추가피해', '', 3800, 560, 2100, 122, '레전드', 0, 0, 0)

insert into card_main values
('1', '광기의마녀폴른', '모든기술효과 20%', '일반공격피해 16.8%', 3600, 510, 1075, 172, '한정', 0.2, 0.2, 0)

insert into card_main values
('1', '김첨지네셋째딸', '일반공격피해 15%', '공격력 1250', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('1', '로제산타', '모든기술효과 20%', '공격피해감소 17.3%', 3600, 510, 1075, 172, '한정', 0.2, 0.2, 0.173)

insert into card_main values
('1', '로즈데라', '일반공격시 30% 추가관통피해', '', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('1', '루시펠', '공격시 50%확률로 5000 추가피해', '', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('1', '성탄절의프레이즈', '모든기술효과 20%', '공격력 1500', 3600, 810, 1075, 112, '한정', 0.2, 0.2, 0)

insert into card_main values
('1', '송판서네둘째딸', '공격시 2500 추가피해', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('1', '시월의프레이즈', '공격피해감소 15%', '체력 7000', 5100, 510, 1075, 112, '한정', 0, 0, 0.15)

insert into card_main values
('1', '어사드라콘', '기술피해 23%', '모든공격피해 14.6%', 3600, 510, 1825, 112, '한정', 0.376, 0, 0)

insert into card_main values
('1', '인페르나', '연속공격시 70% 피해', '', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('1', '저승차사고도령', '모든공격피해 13%', '공격력 1400', 3600, 810, 1075, 112, '한정', 0.13, 0, 0)

insert into card_main values
('1', '티켓삐에로', '공격피해감소 15%', '모든공격피해 15.6%', 5100, 510, 1075, 112, '한정', 0.156, 0, 0.15)

insert into card_main values
('1', '푸른털의청마', '모든공격피해 18.2%', '체력 4500', 5100, 510, 1075, 112, '한정', 0.182, 0, 0)

insert into card_main values
('1', '푸이20세', '일반공격피해 1250', '공격피해감소 15%', 3600, 510, 1825, 112, '한정', 0, 0, 0.15)

insert into card_main values
('1', '푸이6세', '공격피해감소 15%', '체력 6250', 3600, 810, 1075, 112, '한정', 0, 0, 0.15)

insert into card_main values
('1', '해변의바바라', '체력 6250', '카드공격력 280', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('1', '해변의클라우디아', '체력 6250', '공격력 1400', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('1', '힐다', '모든기술효과 20%', '모든공격피해 14.6%', 5100, 510, 1075, 112, '한정', 0.346, 0.2, 0)

insert into card_main values
('1', '니콜라스', '모든공격피해 15.6%', '방어력 3000', 5100, 510, 1075, 112, '한정', 0.156, 0, 0)

insert into card_main values
('1', '지도자드라칸', '카드공격력 400', '모든공격피해 6%', 3600, 510, 1075, 172, '일반', 0.06, 0, 0)

insert into card_main values
('1', '로테만', '공격력 2000', '모든공격피해 6%', 3600, 810, 1075, 112, '투기', 0.06, 0, 0)

insert into card_main values
('1', '롤랑', '모든공격피해 15.6%', '일반공격피해 12%', 5100, 510, 1075, 112, '투기', 0.156, 0, 0)

insert into card_main values
('1', '무닌', '공격력 2500', '', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('1', '시그룬', '방어력 6625', '', 3600, 510, 1825, 112, '투기', 0, 0, 0)

insert into card_main values
('1', '유릭투스', '일반공격피해 2500', '', 3600, 510, 1075, 172, '투기', 0, 0, 0)

insert into card_main values
('1', '카르가스', '모든기술효과 40%', '', 5100, 510, 1075, 112, '투기', 0.4, 0.4, 0)

insert into card_main values
('1', '패트리샤', '모든공격피해 26%', '', 3600, 810, 1075, 112, '투기', 0.26, 0, 0)

insert into card_main values
('1', '피오라', 'HP가 60% 이하일때 일반공격피해 60%', '', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('1', '헤레이스', '체력 12500', '', 3600, 510, 1075, 172, '투기', 0, 0, 0)

insert into card_main values
('1', '황녀바바라', '카드공격력 500', '', 3600, 510, 1825, 112, '투기', 0, 0, 0)

insert into card_main values
('1', '샨드라', '모든공격피해 7.8%', '일반공격피해 1900', 5100, 510, 1075, 112, '투기', 0.078, 0, 0)

---------------

insert into card_main values
('1', '산타드라', '방어력 25%', '일반공격피해 15%', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('1', '고대의베르실', '방어력 3125', '카드공격력 250', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '고대의쿠아크란', '공격피해감소 30%', '', 3600, 810, 1075, 112, '일반', 0, 0, 0.3)

insert into card_main values
('1', '고대의트리아크', '체력 6250', '방어력 3125', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '고대의펠렁', '일반공격피해 30%', '', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '고라', '일반공격피해 15%', '일반공격피해 1250', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '그렌가르', '일반공격피해 1250', '카드공격력 250', 3600, 510, 1075, 172, '일반', 0, 0, 0)

insert into card_main values
('1', '나비여왕블린데라', '공격피해감소 21%', '카드공격력 150', 3600, 510, 1825, 112, '일반', 0, 0, 0.21)

insert into card_main values
('1', '누아카', '모든공격피해 13%', '공격피해감소 15%', 3600, 810, 1075, 112, '일반', 0.13, 0, 0.15)

insert into card_main values
('1', '대마법사냥코', '기술피해 46%', '', 3600, 510, 1075, 172, '일반', 0.46, 0, 0)


---------------------------------

insert into card_main values
('1', '도르드라콘', '방어력 20%', '공격력 30%', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '로제타', '모든공격피해 13%', '일반공격피해 1250', 3600, 810, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('1', '멜라웬', '공격피해감소 24%', '방어력 1250', 3600, 510, 1825, 112, '일반', 0, 0, 0.24)

insert into card_main values
('1', '박쥐여왕릴리아카', '일반공격피해 21%', '체력 3750', 3600, 510, 1075, 172, '일반', 0, 0, 0)

insert into card_main values
('1', '불드레이크', '방어력 25%', '기술피해 23%', 3600, 810, 1075, 112, '일반', 0.23, 0, 0)

insert into card_main values
('1', '브류나드', '모든공격피해 18.2%', '체력 3750', 5100, 510, 1075, 112, '일반', 0.182, 0, 0)

insert into card_main values
('1', '스칼렛', '모든공격피해 18.2%', '체력 3750', 5100, 510, 1075, 112, '일반', 0.182, 0, 0)

insert into card_main values
('1', '브리실다', '공격피해감소 15%', '공격력 1250', 5100, 810, 1075, 112, '일반', 0, 0, 0.15)

insert into card_main values
('1', '블레스크', '모든공격피해 13%', '카드공격력 250', 5100, 510, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('1', '시어러', '체력 3750', '공격력 1750', 3600, 810, 1075, 112, '일반', 0, 0, 0)


insert into card_main values
('1', '웰드킨장로', '일반공격피해 15%', '카드공격력 25%', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '이멜다', '모든공격피해 13%', '체력 6250', 3600, 810, 1075, 112, '일반', 0.13, 0, 0)


insert into card_main values
('1', '챠바나', '모든공격피해 20.8%', '카드공격력 100', 3600, 510, 1075, 172, '일반', 0.208, 0, 0)

insert into card_main values
('1', '캘시퍼', '모든공격피해 13%', '공격력 1250', 5100, 510, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('1', '크리스탈', '일반공격피해 24%', '카드공격력 100', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '크림킨드', '일반공격피해 15%', '기술피해 23%', 3600, 510, 1075, 172, '일반', 0.23, 0, 0)



insert into card_main values
('1', '트리아크', '일반공격피해 15%', '공격피해감소 15%', 5100, 510, 1075, 112, '일반', 0, 0, 0.15)

insert into card_main values
('1', '파괴신의배우자', '공격력 1250', '방어력 3125', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '펠렁', '공격피해감소 15%', '기술피해 23%', 3600, 810, 1075, 112, '일반', 0.23, 0, 0.15)

insert into card_main values
('1', '푸이13세', '일반공격피해 18%', '공격력 20%', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '프레이즈', '체력 2500', '공격피해감소 24%', 5100, 510, 1075, 112, '일반', 0, 0, 0.24)

insert into card_main values
('1', '프리마베라', '일반공격피해 1250', '방어력 3125', 3600, 510, 1825, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '힐렌', '모든공격피해 18.2%', '방어력 1875', 3600, 510, 1075, 172, '일반', 0.182, 0, 0)

insert into card_main values
('1', '파도법사아이린', '모든공격피해 15.6%', '카드공격력 250', 3600, 510, 1075, 172, '한정', 0.156, 0, 0)

insert into card_main values
('1', '레드크리스탈', '공격력 1250', '모든공격피해 15.6%', 3600, 810, 1075, 112, '한정', 0.156, 0, 0)

insert into card_main values
('1', '베네딕트', '공격피해감소 21%', '카드공격력 200', 3600, 510, 1825, 112, '한정', 0, 0, 0.21)

insert into card_main values
('1', '카자미르', '체력 7000', '카드 공격력 250', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('1', '하모니', '카드공격력 550', '', 3600, 510, 1075, 172, '한정', 0, 0, 0)


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
(1, '발키테스트', '발키르잔', '100', '불번', '화폭', '재주꾼1', 
30000, 6000, 5000, 400,
4000, 7500, 9000, 10000, 14000,
0, 0, getdate())

insert into card_battle_main
select
	seq, 
	'테스트',
	'공주',
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

insert into card_AIList values ('공격형 재주꾼', '스킬1','공','스킬2','방', GETDATE())
insert into card_AIList values ('방어형 재주꾼', '스킬1','방','스킬2','공', GETDATE())
insert into card_AIList values ('일단 살아야지', '방','스킬1','스킬2','공', GETDATE())
insert into card_AIList values ('크게 노린다', '공','스킬1','스킬2','방', GETDATE())
select * from card_AIList

create table card_shuffle_active
(	
	subseq int identity(1,1) not null primary key,
	seq int not null,
	s_type varchar(50) not null,
	shuffle varchar(50) not null
)

insert into card_shuffle_active values (3, 'LEFT', '공')
insert into card_shuffle_active values (3, 'LEFT', '마')
insert into card_shuffle_active values (3, 'LEFT', '방')
insert into card_shuffle_active values (3, 'LEFT', '공')
insert into card_shuffle_active values (3, 'LEFT', '공')

insert into card_shuffle_active values (3, 'RIGHT', '공')
insert into card_shuffle_active values (3, 'RIGHT', '마')
insert into card_shuffle_active values (3, 'RIGHT', '방')

insert into card_shuffle_active
select seq, 'RIGHT', '방' from card_user where u_id = 'usaki'

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
		and s_type = 'LEFT' and shuffle = '마'
	) a
)

select * From card_user
select * from card_battle_main
select * from card_shuffle_active